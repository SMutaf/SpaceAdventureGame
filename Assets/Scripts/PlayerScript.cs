using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject movementEffect;
    public GameObject bullet;

    Boolean ready = false;
    
    public float thrustPower = 25f;
    float timer = 0;

    Rigidbody2D rb;
    Camera cmr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;

        cmr = Camera.main;

        SetPosition();
    }

    
    void Update()
    {
        Movement();

        FireTheBullet();

        SetMovemenetEffect();

        CameraControl();

        PlayerPositionControl();
    }


    void SetPosition()
    {
        this.transform.position = new Vector2(-7f, 1f);
    }


    void Movement()
    {
        if(Input.GetKey(KeyCode.Space) && ready)
        {
            rb.AddForce(Vector2.up * thrustPower * Time.deltaTime, ForceMode2D.Impulse);


         //   if (this.transform.rotation.z < 0.10f) 
         //       transform.Rotate(0, 0, 50 * Time.deltaTime);
        }
        //else
        //{
        //   Quaternion targetRotation = Quaternion.Euler(0f, 0f, -20f);
        //   transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1.2f * Time.deltaTime);
        //}

        if(Input.GetKeyDown(KeyCode.Space) && !ready)
        {
            rb.gravityScale = 1;
            ready = true;
        }
    }

    void FireTheBullet()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bullet, transform.position + new Vector3(0.32f, 0, 0), Quaternion.identity);
        }
    }

    void SetMovemenetEffect()
    {
        timer += Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && timer > 0.2f ) 
        {
            GameObject temp =  Instantiate(movementEffect, transform.position, Quaternion.identity);
            timer = 0;
        }
    }

    void CameraControl()
    {
        if (Input.GetKey(KeyCode.Space) && cmr.orthographicSize < 5.3f)
            cmr.orthographicSize += 0.2f * Time.deltaTime;
        else if (cmr.orthographicSize > 5)
            cmr.orthographicSize -= 0.25f * Time.deltaTime;
    }

    void PlayerPositionControl()
    {
        if (this.gameObject.transform.position.y > 7 || this.gameObject.transform.position.y < -7)
            Destroy(this.gameObject);
    }
}
