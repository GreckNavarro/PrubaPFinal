using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    SimpleLinkList<GameObject> spawners;
    SimpleLinkList<GameObject> enemies;
    [SerializeField] GameObject lampara;
    [SerializeField] PlayerControl player;
    [SerializeField] ContenerEnemigos contenedor;
    public int numeroEnemigos = 1;
    public int numerospawn = 10;
    public float radio;

    [SerializeField] GameObject particlesBlood;
    [SerializeField] float timeRespawn;
    [SerializeField] ScoreManager score;
    GameObject enemigoactual;
  

    private float anguloasumar;
    private int comparador = 1500;



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

 
  


    private void GenerarSpawns()
    {
        anguloasumar = (360.0f / numerospawn);


        Vector3 centro = player.transform.position;



        for (int i = 0; i < numerospawn; i++)
        {

            float currentangulo;
            currentangulo = (anguloasumar * i) * Mathf.Deg2Rad;
            GameObject p1 = Instantiate(lampara, (new Vector3(centro.x + Mathf.Cos(currentangulo) * radio, centro.y + Mathf.Sin(currentangulo) * radio)), transform.rotation);
            spawners.AddNodeAtStart(p1);
        }

        Debug.Log(spawners.GetCount());
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

        if(score.puntaje >= comparador)
        {
            
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(GenerarEnemigos());

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
        StartCoroutine(GenerarHordas());
    }


}
