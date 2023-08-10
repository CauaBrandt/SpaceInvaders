using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PlayerControl pc;
    [SerializeField] SaveValues sv;

    public float Speed = 5f;
    void Update()
    {
        if(gameObject.tag == "bullet")
        {
            transform.position += Speed * Time.deltaTime * transform.up;
        }
        else if (gameObject.tag == "enemybullet")
        {
            transform.position += Speed * Time.deltaTime * -transform.up;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemybullet")
        {
            if (gameObject.tag == "bullet")
            {
                Destroy(gameObject);
                Destroy(col.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "destroybullet")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "enemy")
        {
            if (gameObject.tag == "bullet")
            {
                Destroy(gameObject);
                Destroy(col.gameObject);
                sv.score += 10;
            }
        }
    }
}
