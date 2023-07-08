using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbujaController : MonoBehaviour
{
    [SerializeField] int velocidad = 1;
    private int tiempodeduracion = 8;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] AudioSource audiosource;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSound(AudioSource newsound) // O(1)
    {
        audiosource = newsound; //2
    }
    void Start()
    {
        Destroy(gameObject, tiempodeduracion);
    }

    
    public void ChangeVelocity(float angulo) // O(1)
    {
        rb.velocity = new Vector2(velocidad * Mathf.Cos(angulo), velocidad * Mathf.Sin(angulo)); //3
    }


    private void OnMouseDown()
    {
        PopBubble();
    }

    private void PopBubble()
    {

        audiosource.Play();
        Destroy(gameObject);
    }
}
