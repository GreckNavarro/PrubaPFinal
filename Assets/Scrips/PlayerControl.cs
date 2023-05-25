using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D myRB;
    [SerializeField] float velocity = 5;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 target;
    public Pilas.StackP<ArmaSO> armas;
    [SerializeField] private ArmaSO currentArma;
    [SerializeField] private Armas armaenmano;



    // Disparo

   


    public GameObject GetPositionArma()
    {
        return armaenmano.gameObject;
    }



    private void Awake()
    {
        currentArma.SetPlayer(this);
    }


    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        armas = new Pilas.StackP<ArmaSO>();
        armas.Push(currentArma);

    }
    void Update()
    {
        MovementPlayer();
        Apuntar();
        if (Input.GetKeyDown(KeyCode.Space))
        {       

            currentArma.Shoot();

        }
        Debug.Log(target);
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
        if (armas.Count() > 0)
        {
            armas.Pop();
            currentArma = armas.GetTop();
            currentArma.SetPlayer(this);
            armaenmano.SetSprite(currentArma.GetSprite());
        }
        else if(armas.Count() == 0)
        {
            Debug.Log("Ya no se puede borrar papu");
        }
        Debug.Log(armas.Count());
    }
    public Vector2 GetVector(Vector2 direccion)
    {
        Vector2 enviar = target - transform.position;
        direccion = enviar;
        return direccion;
    }







    public void MovementPlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 Inputs = new Vector2(horizontalInput, verticalInput);
        myRB.velocity = Inputs * velocity;
    }
    public void Apuntar()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadianes = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        float angulosgrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, angulosgrados);

    }
}
