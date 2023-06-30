using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ControladorEnemy : MonoBehaviour
{
    [SerializeField] PlayerControl player;
    [SerializeField] Rigidbody2D myRB2D;
    [SerializeField] int velocity;
    [SerializeField] int vida;
    GameObject particles;
    [SerializeField] int damage;
    [SerializeField] int puntaje;


    public event Action<int> onEnemyDestroy;






    private float angulosgrados;

    public void SetLayer(int number)
    {
        this.gameObject.layer = number;
    }

    public void SetParticle(GameObject particlesblood)
    {
        particles = particlesblood;
    }
    public int GetDamage()
    {
        return damage;
    }
    private void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);
            Mirar();
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

    public void RecibirDaño(int damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            Destroy(gameObject);
            onEnemyDestroy?.Invoke(puntaje);
            GameObject particles1 = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(particles1, 1f);
        }
    }

    private void Mirar()
    {
        float anguloRadianes = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
        angulosgrados = (Mathf.Rad2Deg * anguloRadianes) - 90;
        transform.rotation = Quaternion.Euler(0, 0, angulosgrados);
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
            Destroy(gameObject); //Hacer que mi enemigo vaya para atrás
        }
    }
 

  
}
