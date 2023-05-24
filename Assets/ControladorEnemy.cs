using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemy : MonoBehaviour
{
    [SerializeField] PlayerControl player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Pop();
            Destroy(gameObject);
        }
    }
}
