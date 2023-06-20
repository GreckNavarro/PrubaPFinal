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
    private Transform Disparador;
    [SerializeField] LineRenderer linerender;
    private int proyectil;
    Vector2 direccion;
    private int distance = 10;



    // Disparo
    private float angulosgrados;


    public Vector2 DireccionShot()
    {
        direccion = target - transform.position;
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
        
        if (Input.GetMouseButtonDown(0))
        {

            currentArma.Shoot();
            if(currentArma.GetProyectil() == 0)
            {
                StartCoroutine(ShootLaser());
            }

        }
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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 Inputs = new Vector2(horizontalInput, verticalInput);
        myRB.velocity = Inputs * velocity;
    }
    private void Apuntar()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadianes = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        angulosgrados = (Mathf.Rad2Deg * anguloRadianes) - 90;
        transform.rotation = Quaternion.Euler(0, 0, angulosgrados);


    }


    IEnumerator ShootLaser()
    {

        Vector3 endposition = ((Vector3)direccion * distance) + Disparador.position;
        linerender.positionCount = 2;
        linerender.SetPositions(new Vector3[] { Disparador.position, endposition});
        yield return new WaitForSeconds(0.25f);
        linerender.positionCount = 0;
    }
}
