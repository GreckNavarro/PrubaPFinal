using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorArmas : MonoBehaviour
{
    [SerializeField] GameObject[] armas;
    [SerializeField] PlayerControl player;
    private GameObject armagenerada;
    void Start()
    {
        StartCoroutine(GenerarArma());
    }



    IEnumerator GenerarArma()
    {
        if(armagenerada == null)
        {
            int random = Random.Range(0, armas.Length);
            armagenerada = Instantiate(armas[random], transform.position, armas[random].transform.rotation);
            armagenerada.GetComponent<ControladorArma>().SetPlayer(player);
            yield return new WaitForSeconds(30);
            StartCoroutine(GenerarArma());
        }
        else
        {
            Debug.Log("Hay un arma");
            yield return new WaitForSeconds(30);
            StartCoroutine(GenerarArma());
        }

    }
}
