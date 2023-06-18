using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Vector2 VectorToMove;
    [SerializeField] int speed;



  



    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, VectorToMove, speed * Time.deltaTime);
    }


    public void ChangeMovePosition(Vector2 destiny)
    {
        VectorToMove = destiny;
    }
}
