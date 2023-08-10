using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] SaveValues sv;

    public TextMeshPro BarrierLivesT;

    private void Update()
    {
        if(gameObject.name == "Barrier")
        {
            if (sv.BarrierLives == 0)
            {
                Destroy(gameObject);
            }
            BarrierLivesT.text = sv.BarrierLives.ToString();
        }
        else if(gameObject.name == "Barrier2")
        {
            if (sv.BarrierLives2 == 0)
            {
                Destroy(gameObject);
            }
            BarrierLivesT.text = sv.BarrierLives2.ToString();
        }
        else if(gameObject.name == "Barrier3")
        {
            if (sv.BarrierLives3 == 0)
            {
                Destroy(gameObject);
            }
            BarrierLivesT.text = sv.BarrierLives3.ToString();
        }
        else if(gameObject.name == "Barrier4")
        {
            if (sv.BarrierLives4 == 0)
            {
                Destroy(gameObject);
            }
            BarrierLivesT.text = sv.BarrierLives4.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet" ||  col.gameObject.tag == "enemybullet")
        {
            if (gameObject.name == "Barrier")
            {
                sv.BarrierLives--;
            }
            else if (gameObject.name == "Barrier2")
            {
                sv.BarrierLives2--;
            }
            else if (gameObject.name == "Barrier3")
            {
                sv.BarrierLives3--;
            }
            else if (gameObject.name == "Barrier4")
            {
                sv.BarrierLives4--;
            }
            Destroy(col.gameObject);
        }
    }
}
