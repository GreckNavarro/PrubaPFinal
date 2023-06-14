using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenerEnemigos : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    GameObject[] enemigos;


    private void Start()
    {
        enemigos = new GameObject[2];
        enemigos[0] = enemy1;
        enemigos[1] = enemy2;
    }
    public GameObject[] GetEnemies()
    {
        return enemigos;
    }
}
