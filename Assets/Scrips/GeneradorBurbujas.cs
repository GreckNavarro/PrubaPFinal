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
    IEnumerator GenerarBurbujas() // TIEMPO ASINTÓTICO O(N) --> Se llama indefinidamente en el Start()
    {
        float currentangulo = Random.Range(65,115); //3
        currentangulo = currentangulo * Mathf.Deg2Rad; // 3
        GameObject burbuja = Instantiate(prefabsBurbuja, transform.position, prefabsBurbuja.transform.rotation); //3
        burbuja.GetComponent<BurbujaController>().ChangeVelocity(currentangulo); // O(1)
        burbuja.GetComponent<BurbujaController>().SetSound(audiopop); //O(1)

        yield return new WaitForSeconds(1); // 2
        StartCoroutine(GenerarBurbujas()); // O(n)

    }

}
