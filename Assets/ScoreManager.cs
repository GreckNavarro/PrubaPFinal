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

    public event Action InvokeBoss;


    private int puntaje = 0;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(puntaje);
        Debug.Log(maximos);
    }

    private void OnGUI()
    {
        texto.text = "Score: " + puntaje;
    }



    public void HandleEnemyDestroy(int bonuspuntaje)
    {
        puntaje += bonuspuntaje;
        maximos += bonuspuntaje;
        InvocarBoss();

    }
    public void InvocarBoss()
    {
        if (maximos >= 100)
        {
            InvokeBoss?.Invoke();
            maximos = 0;
        }
    }
}
