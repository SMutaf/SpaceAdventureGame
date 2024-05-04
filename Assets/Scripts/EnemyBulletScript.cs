using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;
    public GameObject explosionSystem;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 movement = new Vector2(-speed, 0) * Time.deltaTime;

        this.transform.Translate(movement);

        if (this.transform.position.x < -11)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explosionSystem, collision.transform.position ,Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
