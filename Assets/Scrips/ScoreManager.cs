using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject muerte;
    [SerializeField] GameObject advertencia;
    [SerializeField] GameObject vidaenemigo;

    private int vida;
    int maximos = 0;
    int enemigos = 0;

    PlayerControl playerController;

    [SerializeField] TMP_Text texto;
    [SerializeField] TMP_Text live;

    [SerializeField] ScoreSO newScore;



    bool bossactived;
    public event Action InvokeBoss;
    public event Action NextEnemie;


    private int puntaje = 0;


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
        texto.text = puntaje.ToString();
        live.text = vida.ToString();
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
        if (enemigos >= 500)
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
            Time.timeScale = 0;
            muerte.SetActive(true);
            vidaenemigo.SetActive(false);
            advertencia.SetActive(false);
        }
    }



    public void InvocarBoss()
    {
        if (maximos >= 500)
        {
            InvokeBoss?.Invoke();
            Debug.Log(maximos);
            maximos = 0;

        }
       
    }


}
