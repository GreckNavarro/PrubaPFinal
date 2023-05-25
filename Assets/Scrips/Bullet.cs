using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    [SerializeField] PlayerControl player;
    [SerializeField] Vector2 direccion;
    [SerializeField] Rigidbody2D rb;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetPlayer(PlayerControl newplayer)
    {
        player = newplayer;
        direccion = player.GetComponent<PlayerControl>().GetVector(direccion);
        Debug.Log(direccion); 
        rb.velocity = direccion * velocidad; 

    }
}
