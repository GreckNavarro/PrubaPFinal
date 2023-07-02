using System.Collections;
using TMPro;
using UnityEngine;

public class ScoresPrint : MonoBehaviour
{

    [SerializeField] TMP_Text[] listascores;
    [SerializeField] ScoreSO score;
    int[] scores;


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
    
        for (int i = 0; i < listascores.Length; i++)
        {
            listascores[i].text = "Score: " + scores[i];
        }

    }
}
