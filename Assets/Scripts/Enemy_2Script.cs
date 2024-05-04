using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2Script : MonoBehaviour
{

    public GameObject bulletUp;
    public GameObject bulletDown;
    public GameObject bulletLeft;

    public float enemy_2_Speed;
    float timer;

    void Start()
    {
        timer = Random.Range(1f, 2.3f);
    }

    void Update()
    {
        Enemy_2_Movement();
        Enemy_2_Fire();
    }

    void Enemy_2_Movement()
    {
        this.transform.Translate(Vector2.left * enemy_2_Speed * Time.deltaTime);

        if (this.transform.position.x < -11)
        {
            timer = Random.Range(1f, 2.3f);
            this.transform.position = new Vector3(Random.Range(12, 30), Random.Range(-4f, 5f), 0);
        }
    }

    void Enemy_2_Fire()
    {
        timer += Time.deltaTime;

        if (timer > 2.5F && this.gameObject.transform.position.x < 11)
        {
            Instantiate(bulletUp, transform.position, Quaternion.identity);
            Instantiate(bulletDown, transform.position, Quaternion.identity);
            Instantiate(bulletLeft, transform.position, Quaternion.identity);
            timer = 0;
        }
    }

}
