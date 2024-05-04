using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet;
    public float enemySpeed;
    float timer = 0;
   
    void Update()
    {
        EnemyMovement();

        EnemyFire();
    }

    void EnemyMovement()
    {
        this.transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);

        if(this.transform.position.x < -11)
            this.transform.position = new Vector3(Random.Range(12, 30), Random.Range(-4f, 5f), 0);
    }

    void EnemyFire()
    {

        timer += Time.deltaTime;

        if (timer > 3 && this.gameObject.transform.position.x < 11)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0;
        }

    }
}
