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

    bool bossactived;

    public event Action InvokeBoss;


    public int puntaje = 0;


    public void SetBool(bool actived)
    {
        bossactived = actived;
    }


    private void Awake()
    {
        vida = 100;
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
        if (bossactived == false)
        {
            maximos += bonuspuntaje;
            InvocarBoss();
        }

    }

    private void HandlePlayerDamaged(int damage)
    {
        vida -= damage;

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
