using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    private int tiempodeduracion;

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
  
}
