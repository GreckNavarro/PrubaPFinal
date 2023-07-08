using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    SimpleLinkList<GameObject> spawners;
    SimpleLinkList<GameObject> enemies;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject particlesBlood;
    GameObject enemigoactual;

    [SerializeField] PlayerControl player;
    [SerializeField] ContenerEnemigos contenedor;



    public int numeroEnemigos = 2;
    public int numerospawn = 10;
    public float radio;
    private int indicador = 0;
    private float anguloasumar;
    [SerializeField] float timeRespawn;


    [SerializeField] ScoreManager score;
   



    private void Awake()
    {
        score.NextEnemie += ChangeEnemy;
    }

    void Start()
    {
        spawners = new SimpleLinkList<GameObject>();
        enemies = new SimpleLinkList<GameObject>();

        for (int i = 0; i < contenedor.GetEnemies().Length; i++)
        {
            enemies.AddNodeAtEnd(contenedor.GetEnemies()[i]);
        }

        enemigoactual = enemies.GetNodeAtStart();


       

        GenerarSpawns();
        StartCoroutine(GenerarEnemigos());
        StartCoroutine(GenerarHordas());
    }





    private void GenerarSpawns() // TIEMPO ASINTÓTICO O(N)
    {
        anguloasumar = (360.0f / numerospawn); //3


        Vector3 centro = player.transform.position; // 2



        for (int i = 0; i < numerospawn; i++) // 1 + n(1 + Int +2) --> 1 + n(1+17+2) = 20n + 1 
        {

            float currentangulo; // 1
            currentangulo = (anguloasumar * i) * Mathf.Deg2Rad; //3
            GameObject p1 = Instantiate(spawner, (new Vector3(centro.x + Mathf.Cos(currentangulo) * radio, centro.y + Mathf.Sin(currentangulo) * radio)), transform.rotation); //3
            spawners.AddNodeAtStart(p1); // 10
            // 17
        }
        // 3 + 2 + 20n + 1 = 20n + 7
        // O(n)
    }
    private IEnumerator GenerarEnemigos()
    {


        for (int i = 0; i < numeroEnemigos; i++)
        {
            int randomposition = Random.Range(0, spawners.GetCount());
            Vector3 posicionaleatoria = spawners.GetNodeAtPosition(randomposition).transform.position;
            GameObject enemie = Instantiate(enemigoactual, posicionaleatoria, enemigoactual.transform.rotation);
            enemie.GetComponent<ControladorEnemy>().SetPlayer(player);
            enemie.GetComponent<ControladorEnemy>().SetParticle(particlesBlood);
            enemie.GetComponent<ControladorEnemy>().onEnemyDestroy += score.HandleEnemyDestroy;

        }


        yield return new WaitForSeconds(2f);
        if(player != null)
        {
            StartCoroutine(GenerarEnemigos());
        }
     

    }
    private IEnumerator GenerarHordas()
    {

        Vector3 centro = player.transform.position;
        for (int i = 0; i < spawners.GetCount(); i++)
        {
            float currentangulo;
            GameObject posicionspawn = spawners.GetNodeAtPosition(i);
            currentangulo = (anguloasumar * i) * Mathf.Deg2Rad;
            posicionspawn.transform.position = new Vector3(centro.x + Mathf.Cos(currentangulo) * radio, centro.y + Mathf.Sin(currentangulo) * radio, 0);

        }

        for (int i = 0; i < spawners.GetCount(); i++)
        {
            Vector3 posicionspawn = spawners.GetNodeAtPosition(i).transform.position;
            GameObject enemie = Instantiate(enemigoactual, posicionspawn, enemigoactual.transform.rotation);
            enemie.GetComponent<ControladorEnemy>().SetPlayer(player);
            enemie.GetComponent<ControladorEnemy>().SetParticle(particlesBlood);
            enemie.GetComponent<ControladorEnemy>().onEnemyDestroy += score.HandleEnemyDestroy;
        }
        yield return new WaitForSeconds(timeRespawn);
        if (player != null)
        {
            StartCoroutine(GenerarHordas());
        }
            
    }

    private void ChangeEnemy()
    {
        
        if (indicador < enemies.GetCount() - 1)
        {
            timeRespawn = timeRespawn - 1;
            indicador++;
            enemigoactual = enemies.GetNodeAtPosition(indicador);
        }
        else if(indicador == enemies.GetCount() -1)
        {
            Debug.Log("Lista Recorrida");
        }
    }

}
