using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsGameplay : MonoBehaviour
{
    [SerializeField] GameObject MenuPause;
    [SerializeField] GameObject player;
    [SerializeField] GameObject settings;
    public void Pause()
    {
        player.GetComponent<PlayerControl>().GamePaused(true);
        Time.timeScale = 0;
        MenuPause.SetActive(true);


    }
    public void Reanudar()
    {
        player.GetComponent<PlayerControl>().GamePaused(false);
        Time.timeScale = 1;
        MenuPause.SetActive(false);

    }
    public void GoMenu()
    {
        Time.timeScale = 1;
        player.SetActive(false);
        SceneManager.LoadScene("Menú");

    }
   
    public void Settings()
    {
        settings.SetActive(true);
    }

    public void Return()
    {
        settings.SetActive(false);
        
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

}
