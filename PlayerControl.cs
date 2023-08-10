using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Enemys enemy;
    [SerializeField] SaveValues sv;

    public float Speed = 5f;
    private float dir = 0f;
    public bool CanFire;

    public GameObject bullet;
    public Transform bulletSpawn;
    public Rigidbody2D rb;
    public TextMeshProUGUI ScoreT;
    public TextMeshProUGUI livesT;
    public Animator GameOverAni;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            if(Screen.fullScreen == false)
            {
                Screen.fullScreen = true;
            }
            else if(Screen.fullScreen == true)
            {
                Screen.fullScreen = false;
            }
        }

        if (sv.lives == 0)
        {
            GameOverAni.SetBool("IsDead", true);
            enemy.CancelInvoke("EnemyMove");
            enemy.StopAllCoroutines();
        }
        else
        {
            var Shootdelay = Task.Delay(300);
            dir = Input.GetAxis("Horizontal");
            if (dir > 0f)
            {
                rb.velocity = new Vector2(dir * Speed, rb.velocity.y);
            }
            else if (dir < 0f)
            {
                rb.velocity = new Vector2(dir * Speed, rb.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.Space) && CanFire == true)
            {
                Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
                CanFire = false;
                await Shootdelay;
                CanFire = true;
            }
        }
        ScoreT.SetText("Score: "+ sv.score);
        livesT.SetText("Lives: "+ sv.lives);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "enemybullet")
        {
            Destroy(col.gameObject);
            if(sv.lives > 0)
            {
                sv.lives -= 1;
            }
        }
    }
}
