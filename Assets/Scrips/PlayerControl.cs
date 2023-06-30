using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D myRB;
    [SerializeField] float velocity = 5;
    [SerializeField] int live;

    private Vector3 target;
    public Pilas.StackP<ArmaSO> armas;
    [SerializeField] private ArmaSO currentArma;
    [SerializeField] private Armas armaenmano;
    private Transform Disparador;
    [SerializeField] LineRenderer linerender;
    [SerializeField] GameObject particlesburbujas;
    Vector2 direccion;
    private int distance = 10;
    private bool dispararRayo;


    public event Action<int> onPlayerDamaged;


    [Header("InputSystem")]
    Vector2 rawInputMovement;
    Vector3 mouseposition;


    // Disparo
    private float angulosgrados;


    public Vector2 DireccionShot()
    {
        direccion = mouseposition - transform.position;
        return direccion;
    }
    public GameObject GetPositionArma()
    {
        return armaenmano.gameObject;
    }
    
    public Transform GetPositionDisparador()
    {
        return Disparador;
    }



    private void Awake()
    {
        currentArma.SetPlayer(this);
        dispararRayo = true;
        live = 100;
    }

    

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        armas = new Pilas.StackP<ArmaSO>();
        armas.Push(currentArma);
        Debug.Log(armas.Count());
        Disparador = transform.GetChild(0).GetChild(0);

    }
    void Update()
    {
        MovementPlayer();
        Apuntar();
    }
    public void SetStack(ArmaSO armanueva)
    {
        armas.Push(armanueva);
        currentArma = armas.GetTop();
        currentArma.SetPlayer(this);
        armaenmano.SetSprite(currentArma.GetSprite());
        Debug.Log("Sumando");
        Debug.Log(armas.Count());

    }
    public void Pop()
    {
        if (armas.Count() > 1)
        {
            armas.Pop();    
            currentArma = armas.GetTop();
            currentArma.SetPlayer(this);
            armaenmano.SetSprite(currentArma.GetSprite());
        }
        else if (armas.Count() == 1)
        {
            Debug.Log("Ya no se puede borrar papu");
        }
        Debug.Log(armas.Count());
    }

    private void MovementPlayer()
    {
        myRB.velocity = rawInputMovement * velocity;
    }
    private void Apuntar()
    {
    
        float anguloRadianes = Mathf.Atan2(mouseposition.y - transform.position.y, mouseposition.x - transform.position.x);
        angulosgrados = (Mathf.Rad2Deg * anguloRadianes) - 90;
        transform.rotation = Quaternion.Euler(0, 0, angulosgrados);
    }


    IEnumerator ShootLaser()
    {
        dispararRayo = false;
        Vector3 endposition = ((Vector3)direccion * distance) + Disparador.position;
        linerender.positionCount = 2;
        linerender.SetPositions(new Vector3[] { Disparador.position, endposition});
        yield return new WaitForSeconds(0.25f);
        linerender.positionCount = 0;
        yield return new WaitForSeconds(1);
        dispararRayo = true;
    }

    private void RecibirDaño(int damage)
    {
        live -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            RecibirDaño(collision.GetComponent<ControladorEnemy>().GetDamage());
            onPlayerDamaged?.Invoke(collision.GetComponent<ControladorEnemy>().GetDamage());
        }
        else if (collision.gameObject.tag == "Boss")
        {
            RecibirDaño(collision.GetComponent<BossController>().GetDamage());
            onPlayerDamaged?.Invoke(collision.GetComponent<BossController>().GetDamage());
        }
        else if (collision.gameObject.tag == "BossBullet")
        {
            RecibirDaño(collision.GetComponent<BulletEnemy>().GetDamage());
            onPlayerDamaged?.Invoke(collision.GetComponent<BulletEnemy>().GetDamage());
            Destroy(collision.gameObject);
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector2(inputMovement.x, inputMovement.y);
    }

    public void OnAim(InputAction.CallbackContext value)
    {
        Debug.Log(mouseposition);
        Vector2 direccionmouse = Camera.main.ScreenToWorldPoint(value.ReadValue<Vector2>());
        mouseposition = direccionmouse;
    }


    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Hola");
            if (currentArma.GetProyectil() == 0)
            {
                if (dispararRayo == true)
                {
                    currentArma.Shoot();
                    StartCoroutine(ShootLaser());
                }
            }
            else
            {
                currentArma.Shoot();
                Instantiate(particlesburbujas, Disparador.transform.position, particlesburbujas.transform.rotation);
            }
        }
    }


}   
