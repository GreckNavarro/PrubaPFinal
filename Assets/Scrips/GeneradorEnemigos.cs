using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    SimpleLinkList<GameObject> spawners;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject lampara;
    [SerializeField] PlayerControl player;
    public int numeroEnemigos = 1;
    public int numerospawn = 10;
    public float radio;
    public int Oleada = 1;



    private void Awake()
    {

    }
    void Start()
    {
        spawners = new SimpleLinkList<GameObject>();

        GenerarSpawns();
        StartCoroutine(GenerarEnemigos());
        StartCoroutine(GenerarHordas());
    }

    void Update()
    {

    }


    private void GenerarSpawns()
    {
        float anguloasumar = (360.0f / numerospawn);


        Vector3 centro = player.transform.position;



        for (int i = 0; i < numerospawn; i++)
        {
            
            float currentangulo;
            currentangulo = (anguloasumar * i) * Mathf.Deg2Rad;
            GameObject p1 = Instantiate(lampara, (new Vector3(centro.x + Mathf.Cos(currentangulo) * radio,centro.y + Mathf.Sin(currentangulo) * radio)), transform.rotation);
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
            GameObject enemie = Instantiate(enemy, posicionaleatoria, enemy.transform.rotation);
            enemie.GetComponent<ControladorEnemy>().SetPlayer(player);

        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(GenerarEnemigos());

    }
    private IEnumerator GenerarHordas()
    {

       /*for (int i = 0; i < spawners.GetCount(); i++)
        {
            GameObject posicionspawn = spawners.GetNodeAtPosition(i);
            Vector3 desfase = posicionspawn.transform.position - player.transform.position;
            Vector3 nuevaposicion = player.transform.position + desfase;
            posicionspawn.transform.position = nuevaposicion;
        }*/
       
   
        for (int i = 0; i < spawners.GetCount(); i++)
        {
            Vector3 posicionspawn = spawners.GetNodeAtPosition(i).transform.position;
            GameObject enemie = Instantiate(enemy, posicionspawn, enemy.transform.rotation);
            enemie.GetComponent<ControladorEnemy>().SetPlayer(player);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine (GenerarHordas());
    }


}
