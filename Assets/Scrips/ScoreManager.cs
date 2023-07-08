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


    public void HandleEnemyDestroy(int bonuspuntaje) // O(n)
    {
        puntaje += bonuspuntaje; //3
        enemigos += bonuspuntaje; //3
        if (bossactived == false) // 1 + 7 = 8
        {
            maximos += bonuspuntaje; //3
            InvocarBoss(); //4
        }
        if (enemigos >= 500) //1 + 3 = 4
        {
            NextEnemie?.Invoke(); //1
            enemigos = 0; //2

        }
        
        // 18
        // O(n)
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



    public void InvocarBoss() // O(1)
    {
        if (maximos >= 500)// 1 +  3 = 4
        {
            InvokeBoss?.Invoke();//1
            maximos = 0;//2

        }
       
    }


}
