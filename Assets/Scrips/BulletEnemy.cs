using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    private int tiempodeduracion = 8;
    private int damage = 5;
    [SerializeField]private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Destroy(gameObject, tiempodeduracion);

    }
    public int GetDamage()
    {
        return damage;
    }


    public void ChangeVelocity(float angulo)
    {
        rb.velocity = new Vector2(velocidad * Mathf.Cos(angulo), velocidad * Mathf.Sin(angulo));
    }

}
