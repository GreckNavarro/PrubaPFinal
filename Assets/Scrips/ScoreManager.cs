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
    int maximos = 0;

    bool bossactived;

    public event Action InvokeBoss;


    public int puntaje = 0;


    public void SetBool(bool actived)
    {
        bossactived = actived;
    }
    

    // Update is called once per frame
    void Update()
    {
    }

    private void OnGUI()
    {
        texto.text = "Score: " + puntaje;
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
    public void InvocarBoss()
    {
        if (maximos >= 200)
        {
            InvokeBoss?.Invoke();
            Debug.Log(maximos);
            maximos = 0;

        }
    }
}
