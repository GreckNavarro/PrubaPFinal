using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : MonoBehaviour
{
    private Vector2 VectorToMove;
    [SerializeField] int speed;
    [SerializeField] private int vida;
    [SerializeField] private GameObject padre;
    [SerializeField] ScoreManager score;

    private void Awake()
    {
        score.InvokeBoss += HandleBoss;
    }
    private void Start()
    {
        padre.SetActive(false);
    }
    public void HandleBoss()
    {
        padre.SetActive(true);
    }
    private void OnEnable()
    {
        vida = 100;
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, VectorToMove, speed * Time.deltaTime);
    }


    public void ChangeMovePosition(Vector2 destiny)
    {
        VectorToMove = destiny;
    }

    public void RecibirDaño(int damage)
    {
        vida -= damage;
        if(vida <= 0)
        {
            padre.SetActive(false);
        }
    }

}
