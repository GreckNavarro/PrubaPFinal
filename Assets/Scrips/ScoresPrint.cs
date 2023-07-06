using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class ScoresPrint : MonoBehaviour
{

    [SerializeField] TMP_Text[] listascores;
    [SerializeField] ScoreSO score;
    SimpleLinkList<int> scores;


    private void Awake()
    {
        scores = score.GetScore();
    }
    private void OnEnable()
    {
        LlenadoScores();
    }

    public void LlenadoScores()
    {
    
        for (int i = 0; i < scores.GetCount(); i++)
        {
     
                listascores[i].text = "Score: " + scores.GetNodeAtPosition(i);
       
        }

    }
}
