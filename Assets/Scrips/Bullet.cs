using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    [SerializeField] PlayerControl player;
    [SerializeField] Vector2 angulo;
    [SerializeField] Rigidbody2D rb;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetPlayer(PlayerControl newplayer)
    {
        player = newplayer;
        angulo = player.GetComponent<PlayerControl>().GetVector();
        Debug.Log("Angulo disparo: " + angulo);
        rb.velocity = angulo * velocidad;
    }
}
