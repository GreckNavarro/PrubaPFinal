using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsGameplay : MonoBehaviour
{
    [SerializeField] GameObject MenuPause;
    [SerializeField] GameObject player;
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
        Time.timeScale = 1;
        player.SetActive(false);
        SceneManager.LoadScene("Menú");

    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
