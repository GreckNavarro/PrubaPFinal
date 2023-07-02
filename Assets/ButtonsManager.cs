using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] GameObject controles;

    public void GoToPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ActivarControl()
    {
        controles.SetActive(true);
    }

    public void SalirControl()
    {
        controles.SetActive(false);
    }
}
