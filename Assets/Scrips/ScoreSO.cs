using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScorePlayer", menuName = "ScriptableObject/ScorePlayer", order = 2)]


public class ScoreSO : ScriptableObject
{

    [SerializeField] List<int> scores;


    public List<int> GetScore()
    {
        return scores;
    }


    public void NuevoPuntaje(int newScore)
    {
        scores.Add(newScore);
        Debug.Log("Se está ordenando");
        BurbleSortOrden(scores);
        scores.RemoveAt(10);
        Debug.Log("Se ordenandó");
    }

    public void BurbleSortOrden(List<int> maxScore)
    {
        int tmp;
        for (int i = 0; i < maxScore.Count; i++)
        {
            for (int j = 0; j < maxScore.Count - i - 1; j++)
            {
                if (maxScore[j] < maxScore[j + 1])
                {
                    tmp = maxScore[j];
                    maxScore[j] = maxScore[j + 1];
                    maxScore[j + 1] = tmp;
                }
            }
        }
    }

}
