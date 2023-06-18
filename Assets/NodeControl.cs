using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    SimpleLinkList<NodeControl> NodesAdyacentes;
    public string Tag;

    public void SetTag(string newtag)
    {
        Tag = newtag;
    }


    private void Awake()
    {
        NodesAdyacentes = new SimpleLinkList<NodeControl>();
    }


    public NodeControl SelectNextNode()
    {

        int nodeSelected = Random.Range(0, NodesAdyacentes.GetCount());
        return (NodesAdyacentes.GetNodeAtPosition(nodeSelected));


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            NodeControl CurrentNode = SelectNextNode();
            collision.GetComponent<BossController>().ChangeMovePosition(CurrentNode.transform.position);


        }
    }

    public void AddNodeAdjacente(NodeControl nodo)
    {
        NodesAdyacentes.AddNodeAtEnd(nodo);
    }
}
