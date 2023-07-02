using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScorePlayer", menuName = "ScriptableObject/ScorePlayer", order = 2)]


public class ScoreSO : ScriptableObject
{

    [SerializeField] int[] scores;


    public int[] GetScore()
    {
        return scores;
    }

    private void OnEnable()
    {
        if (scores == null)
        {
            scores = new int[10];
        }
    }

    public void NuevoPuntaje(int newScore)
    {
        bool isChanged = false;
        for (int i = 0; i < scores.Length; i++)
        {
            if (newScore > scores[i] && !isChanged)
            {
                int temp = scores[i];
                scores[i] = newScore;
                newScore = temp;
                isChanged = true;
            }
            else if (isChanged == true)
            { 
                break; 
            }

        }
    }

}
