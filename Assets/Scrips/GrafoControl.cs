using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafoControl : MonoBehaviour
{
    SimpleLinkList<NodeControl> allNodesControl;
    public NodeControl currentNodeControl;
    [SerializeField] GameObject Node;
    public GameObject Boss;

    public int radio = 6;
    float anguloasumar;

    private void Awake()
    {
        allNodesControl = new SimpleLinkList<NodeControl>();
        allNodesControl.AddNodeAtStart(currentNodeControl);
        GenerarSpawns();
    }

    private void Start()
    {


       


        AddNodeAdjacentes("-1" , new string[] {"0", "1", "2", "3","4"});
        AddNodeAdjacentes("0", new string[] {"-1" });
        AddNodeAdjacentes("1", new string[] { "-1" });
        AddNodeAdjacentes("2", new string[] { "-1" });
        AddNodeAdjacentes("3", new string[] { "-1" });
        AddNodeAdjacentes("4", new string[] { "-1" });

    }


    private void GenerarSpawns()
    {
        anguloasumar = (360.0f / 5);


        Vector3 centro = Boss.transform.position;



        for (int i = 0; i < 5; i++)
        {

            float currentangulo;
            currentangulo = (anguloasumar * i) * Mathf.Deg2Rad;
            GameObject p1 = Instantiate(Node, new Vector3(centro.x + Mathf.Cos(currentangulo) * radio, centro.y + Mathf.Sin(currentangulo) * radio), transform.rotation);
            p1.GetComponent<NodeControl>().SetTag(i.ToString());
            allNodesControl.AddNodeAtEnd(p1.GetComponent<NodeControl>());
        }
    }

    void AddNodeAdjacentes(string nodeTag, string[] allAdyacentes)
    {
        NodeControl NodeSelected = SearchNode(nodeTag);



        for(int i = 0; i < allAdyacentes.Length; i++)
        {
            NodeSelected.AddNodeAdjacente(SearchNode(allAdyacentes[i]));
        }
    }

  
    NodeControl SearchNode(string tag)
    {
        int position = 0;

        for (int i = 0; i < allNodesControl.GetCount(); i++)
        {
            if (allNodesControl.GetNodeAtPosition(i).Tag == tag)
            {
                position = i;
                break;
            }
        }
        return allNodesControl.GetNodeAtPosition(position);
    }


   
}
