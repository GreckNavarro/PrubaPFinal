using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class BossController : MonoBehaviour
{

    private Vector2 VectorToMove;


    
    [SerializeField] ScoreManager score;
  
    [SerializeField] float cantidadspores = 10;
    private float disparo = 0;
    [SerializeField] int puntajeextra = 100;
    [SerializeField] int speed;
    [SerializeField] private int vida;
    private int damage = 10;

    [SerializeField] GameObject particles;
    [SerializeField] GameObject prefabsSpores;
    [SerializeField] private GameObject padre;
    [SerializeField] GameObject advertencia;
    [SerializeField] ChangeAudios sounds;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bossimage;

    [SerializeField] TMP_Text textovida;
    



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
        bossimage.SetActive(true);


    }
    private void OnEnable()
    {
        vida = 100;
        textovida.text =  vida.ToString();
        if (player != null)
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

    public void RecibirDaño(int damage) // TIEMPO ASINTÓTICO O(1)
    {
        vida -= damage; // 3
        GameObject particles1 = Instantiate(particles, transform.position, Quaternion.identity); //3
        textovida.text = vida.ToString(); //2
        Destroy(particles1, 1f); //1
        if (vida <= 0) // 1 + 10 + O(1)
        {
            padre.SetActive(false); //2
            score.SetBool(false); //2
            transform.position = padre.transform.position; //2
            advertencia.SetActive(false); //2
            bossimage.SetActive(false); //2
            score.HandleEnemyDestroy(puntajeextra); // O(1)
            sounds.ApagarBoss(); // O(1)
        }
        // 11 + O(1)
        // O(1)
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
        yield return new WaitForSeconds(2);
        StartCoroutine(CanalizarAtaque());
    }

}
