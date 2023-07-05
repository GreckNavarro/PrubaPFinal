using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    private int tiempodeduracion;
    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetArma(int newtime)
    {
        tiempodeduracion = newtime;
    }

    private void Start()
    {
        Destroy(gameObject, tiempodeduracion);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.GetComponent<ControladorEnemy>().RecibirDaño(damage);
        }
        else if(collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
            collision.GetComponent<BossController>().RecibirDaño(damage);
        }
        else if (collision.gameObject.tag == "Objetos")
        {
            Destroy(gameObject);
        }
    }

}
