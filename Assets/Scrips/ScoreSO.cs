using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScorePlayer", menuName = "ScriptableObject/ScorePlayer", order = 2)]


public class ScoreSO : ScriptableObject
{

    SimpleLinkList<int> scores;


    public SimpleLinkList<int> GetScore()
    {
        return scores;
    }


    public void NuevoPuntaje(int newScore)
    {
        if (scores == null)
        {
            scores = new SimpleLinkList<int>();
            for (int i = 0; i < 10; i++)
            {
                scores.AddNodeAtStart(0);
            }
        }
        scores.AddNodeAtEnd(newScore);
        Debug.Log("Se está ordenando");
        BurbleSortOrden(scores);
        scores.RemoveNodeAtPosition(10);
        Debug.Log("Se ordenandó");
        PrintList(scores);
    }

    public void BurbleSortOrden(SimpleLinkList<int> maxScore)
    {
        int tmp;
        for (int i = 0; i < maxScore.GetCount(); i++)
        {
            for (int j = 0; j < maxScore.GetCount() - i - 1; j++)
            {
                if (maxScore.GetNodeAtPosition(j) < maxScore.GetNodeAtPosition(j + 1))
                {
                    tmp = maxScore.GetNodeAtPosition(j);
                    maxScore.ModifyAtPosition(maxScore.GetNodeAtPosition(j + 1), j);
                    maxScore.ModifyAtPosition(tmp, j + 1);
                }
            }
        }
    }
    public void PrintList(SimpleLinkList<int> maxScore)
    {
        for(int i = 0; i < maxScore.GetCount(); i++)
        {
            Debug.Log(scores.GetNodeAtPosition(i));
        }
    }

}
