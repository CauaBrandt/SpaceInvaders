using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveValues : MonoBehaviour
{
    public int score = 0;
    public Vector2 dir = Vector2.right;
    public int lives = 3;
    public int BarrierLives = 30;
    public int BarrierLives2 = 30;
    public int BarrierLives3 = 30;
    public int BarrierLives4 = 30;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            if (Screen.fullScreen == false)
            {
                Screen.fullScreen = true;
            }
            else if (Screen.fullScreen == true)
            {
                Screen.fullScreen = false;
            }
        }
    }
}
