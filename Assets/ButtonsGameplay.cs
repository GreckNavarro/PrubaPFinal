using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsGameplay : MonoBehaviour
{
    [SerializeField] GameObject MenuPause;
    public void Pause()
    {
        Time.timeScale = 0;
        MenuPause.SetActive(true);
    }
    public void Reanudar()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menú");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
