using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SaveValues sv;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        sv.lives = 3;
        sv.score = 0;
        sv.BarrierLives = 30;
        sv.BarrierLives2 = 30;
        sv.BarrierLives3 = 30;
        sv.BarrierLives4 = 30;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
