using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeteorsScript : MonoBehaviour
{
    GameObject[] meteors = new GameObject[3];
    public GameObject meteor;
    public float meteorSpeed;
    void Start()
    {
        CreateMeteors();
    }


    void Update()
    {
        MeteorMovements();
    }

    void CreateMeteors()
    {
        Vector2 firstLocation;

        for (int i = 0; i < meteors.Length; i++)
        {
            firstLocation = new Vector2(Random.Range(13, 40), Random.Range(-4, 5));

            GameObject temp = Instantiate(meteor, transform);

            meteors[i] = temp;

            meteors[i].transform.position = firstLocation;
        }
    }

    void MeteorMovements()
    {
        foreach(GameObject x in meteors)
        {
            x.transform.Translate(Vector2.left * meteorSpeed * Time.deltaTime);

            if(x.transform.position.x < -11)
                x.transform.position = new Vector2(Random.Range(13, 40), Random.Range(-4, 5));
        }
    }
}
