using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public GameObject player;
    private int vida;
    PlayerControl playerController;
    [SerializeField] TMP_Text texto;
    [SerializeField] TMP_Text live;
    int maximos = 0;
    int enemigos = 0;


    [SerializeField] ScoreSO newScore;



    bool bossactived;
    public event Action InvokeBoss;
    public event Action NextEnemie;


    public int puntaje = 0;


    public void SetBool(bool actived)
    {
        bossactived = actived;
    }


    private void Awake()
    {
        vida = 20;
        playerController = player.GetComponent<PlayerControl>();
    }

    private void OnGUI()
    {
        texto.text = "Score: " + puntaje;
        live.text = "Vida: " + vida;
    }

    private void Start()
    {
        playerController.onPlayerDamaged += HandlePlayerDamaged;
    }


    public void HandleEnemyDestroy(int bonuspuntaje)
    {
        puntaje += bonuspuntaje;
        enemigos += bonuspuntaje;
        if (bossactived == false)
        {
            maximos += bonuspuntaje;
            InvocarBoss();
        }
        if (enemigos >= 100)
        {
            NextEnemie?.Invoke();
            enemigos = 0;

        }

    }

    private void HandlePlayerDamaged(int damage)
    {
        vida -= damage;
        if(vida <= 0)
        {
            newScore.NuevoPuntaje(puntaje);
            Destroy(player);
        }
    }



    public void InvocarBoss()
    {
        if (maximos >= 1000)
        {
            InvokeBoss?.Invoke();
            Debug.Log(maximos);
            maximos = 0;

        }
       
    }


}
