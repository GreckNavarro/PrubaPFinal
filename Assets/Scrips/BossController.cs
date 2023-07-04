using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class BossController : MonoBehaviour
{
    private Vector2 VectorToMove;
    [SerializeField] int speed;
    [SerializeField] private int vida;
    [SerializeField] private GameObject padre;
    [SerializeField] ScoreManager score;
    [SerializeField] GameObject prefabsSpores;
    [SerializeField] float cantidadspores = 10;
    private float disparo = 0;
    [SerializeField] GameObject particles;
    [SerializeField] int puntajeextra = 100;
    [SerializeField] GameObject advertencia;
    [SerializeField] ChangeAudios sounds;
    [SerializeField] GameObject player;

    private int damage = 10;

    private void Awake()
    {
        padre.SetActive(false);
        score.InvokeBoss += HandleBoss;
    }
    private void Start()
    {
        score.SetBool(false);
    }

    public int GetDamage()
    {
        return damage;
    }
    public void HandleBoss()
    {
        padre.SetActive(true);
        score.SetBool(true);
        advertencia.SetActive(true);


    }
    private void OnEnable()
    {
        vida = 50;
        if(player != null)
        {
            StartCoroutine(CanalizarAtaque());
        }
        else if(player == null)
        {
            Destroy(this.gameObject);
        }
            
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, VectorToMove, speed * Time.deltaTime);
    }


    public void ChangeMovePosition(Vector2 destiny)
    {
        VectorToMove = destiny;
    }

    public void RecibirDaño(int damage)
    {
        vida -= damage;
        GameObject particles1 = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(particles1, 1f);
        if (vida <= 0)
        {
            padre.SetActive(false);
            score.SetBool(false);
            advertencia.SetActive(false);
            score.HandleEnemyDestroy(puntajeextra);
            sounds.ChangeAudioClip();
        }
    }

    IEnumerator CanalizarAtaque()
    {
        if(disparo == 0)
        {
            float anguloasumar = 360 / cantidadspores;
            Debug.Log("disparando");
            for (int i = 0; i < cantidadspores; i++)
            {
                float currentangulo;
                currentangulo = (anguloasumar * i) * Mathf.Deg2Rad;
                GameObject bullet = Instantiate(prefabsSpores, new Vector3(transform.position.x + Mathf.Cos(currentangulo), transform.position.y + Mathf.Sin(currentangulo)), prefabsSpores.transform.rotation);
                bullet.GetComponent<BulletEnemy>().ChangeVelocity(currentangulo);


            }
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CanalizarAtaque());
    }

}
