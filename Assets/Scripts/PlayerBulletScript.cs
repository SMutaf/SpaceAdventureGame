using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float speed;
    public GameObject explosionSystem;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
       Vector2 movement = new Vector2(speed, 0) * Time.deltaTime;  

       this.transform.Translate(movement);

        if (this.transform.position.x > 11)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            Instantiate(explosionSystem, collision.transform.position, Quaternion.identity);
            collision.gameObject.transform.position = new Vector3(Random.Range(12, 50), Random.Range(-4f, 5f), 0);
            Destroy(this.gameObject); 
        }
    }
}
