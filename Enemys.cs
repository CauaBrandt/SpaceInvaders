using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemys : MonoBehaviour
{
    [SerializeField] SaveValues sv;

    public GameObject BlueBullet;
    public GameObject RedBullet;
    public GameObject GreenBullet;

    public List<Transform> EnemysList = new List<Transform>();
    public List<GameObject> Bullets = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("EnemyMove", 0, 1.5f);
        StartCoroutine(EnemyShoot());
    }
    private void Update()
    {
        EnemysList.RemoveAll(I => I == null);

        if(EnemysList.Count == 0)
        {
            if (sv.lives < 3)
            {
                sv.lives += 1;
            }
            SceneManager.LoadScene(1);
        }
    }
    void EnemyMove()
    {
        transform.Translate(sv.dir);
    }
    IEnumerator EnemyShoot()
    {
        while (EnemysList.Count > 0)
        {
            float RandomTimer = Random.Range(0.5f, 2);
            yield return new WaitForSeconds(RandomTimer);
            int RandomIndex = Random.Range(0, EnemysList.Count);
            int RandomBullet = Random.Range(0, Bullets.Count);
            Instantiate(Bullets[RandomBullet], EnemysList[RandomIndex].position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "changeDir")
        {
            if(sv.dir == Vector2.right)
            {
                sv.dir = Vector2.left;
            }
            else if(sv.dir == Vector2.left)
            {
                sv.dir = Vector2.right;
            }
        }
    }
}
