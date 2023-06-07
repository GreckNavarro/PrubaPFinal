using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemy : MonoBehaviour
{
    [SerializeField] PlayerControl player;
    [SerializeField] Rigidbody2D myRB2D;
    [SerializeField] int velocity;

    private void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);
    }


    public void SetPlayer(PlayerControl newplayer)
    {
        player = newplayer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Pop();
            Destroy(gameObject);
        }
    }
 

  
}
