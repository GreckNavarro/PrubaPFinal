using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBurbujas : MonoBehaviour
{
    [SerializeField] GameObject prefabsBurbuja;
    [SerializeField] AudioSource audiopop;
    void Start()
    {
       StartCoroutine(GenerarBurbujas());
    }
    IEnumerator GenerarBurbujas()
    {
        float currentangulo = Random.Range(65,115);
        currentangulo = currentangulo * Mathf.Deg2Rad;
        GameObject burbuja = Instantiate(prefabsBurbuja, transform.position, prefabsBurbuja.transform.rotation);
        burbuja.GetComponent<BurbujaController>().ChangeVelocity(currentangulo);
        burbuja.GetComponent<BurbujaController>().SetSound(audiopop);

        yield return new WaitForSeconds(1);
        StartCoroutine(GenerarBurbujas());
    }

}
