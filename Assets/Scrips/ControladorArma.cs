using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    [SerializeField] ArmaSO arma;
    [SerializeField] PlayerControl player;

    public void SetPlayer(PlayerControl newplayer)
    {
        player = newplayer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.SetStack(arma);
            Destroy(gameObject);
        }
    }


}
