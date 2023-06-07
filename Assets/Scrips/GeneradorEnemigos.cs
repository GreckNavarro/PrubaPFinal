using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    SimpleLinkList<GameObject> spawners;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject lampara;
    [SerializeField] PlayerControl player;
    public int numeroEnemigos;
    public int Oleada = 1;


    private void Awake()
    {
        
    }
    void Start()
    {
        spawners = new SimpleLinkList<GameObject>();
        GameObject p1 = Instantiate(lampara, (new Vector3(0, -10, 0)), transform.rotation);
        spawners.AddNodeAtStart(p1);
        GameObject p2 = Instantiate(lampara, (new Vector3(0, 10, 0)), transform.rotation);
        spawners.AddNodeAtStart(p2);
        GameObject p3 = Instantiate(lampara, (new Vector3(10, 0, 0)), transform.rotation);
        spawners.AddNodeAtStart(p3);
        GameObject p4 = Instantiate(lampara, (new Vector3(-10, 0, 0)), transform.rotation);
        spawners.AddNodeAtStart(p4);

        //prefabsEnemigos = new SimpleLinkList<GameObject>();
        GenerarEnemigos(4);
    }

    void Update()
    {
        
    }
    void GenerarEnemigos(int enemigos)
    {
        for (int i = 0; i < enemigos; i++)
        {
            int randomposition = Random.Range(0, spawners.GetCount());
            Vector3 posicionaleatoria = spawners.GetNodeAtPosition(randomposition).transform.position;
            GameObject enemie =  Instantiate(enemy, posicionaleatoria, enemy.transform.rotation);
            enemie.GetComponent<ControladorEnemy>().SetPlayer(player);
        }
    }
}
