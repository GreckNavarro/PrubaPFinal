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
    private ArmaSO currentArma;
    private Armas armaenmano;

    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        armas = new Pilas.StackP<ArmaSO>();

    }


    void Update()
    {
        MovementPlayer();
        Apuntar();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (armas.Count() > 0)
            {
                currentArma.Shoot();
            }

        }
    }
    public void SetStack(ArmaSO armanueva)
    {
        armas.Push(armanueva);
        currentArma = armas.GetTop();
        //armaenmano.SetSprite()
        Debug.Log("Sumando");
        Debug.Log(armas.Count());
        
    }
    public void Pop()
    {
        armas.Pop();
        currentArma = armas.GetTop();
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
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);

    }
}
