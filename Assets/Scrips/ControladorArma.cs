using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    [SerializeField] ArmaSO arma;
    [SerializeField] PlayerControl player;



    [SerializeField] private Vector3 angulo;
     private Quaternion qz = Quaternion.identity;
     private Quaternion qx = Quaternion.identity;
     private Quaternion qy = Quaternion.identity;

    private float anguloSen;
    private float anguloCos;


    private Quaternion r = Quaternion.identity;


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

    private void FixedUpdate()
    {
        
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulo.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulo.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        r = qz;

        transform.rotation = transform.rotation * r ;
    }

}
