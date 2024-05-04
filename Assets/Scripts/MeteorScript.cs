using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject explosionEffect;
    public float moveSpeed = 5f;
    Vector3 targetPosition;


    void Start()
    {
        targetPosition = new Vector3(Random.Range(-16, -12), Random.Range(-5, 6), 0);
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
    
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize(); 

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if(this.transform.position.x < -11)
        {
            this.transform.position = new Vector3(Random.Range(12,70), Random.Range(-8,8), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
