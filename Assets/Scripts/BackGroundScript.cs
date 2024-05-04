using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public GameObject star;
    public int numOfStars;
    public float starSpeed;

    public GameObject planets;
    public float planetSpeed;

    public GameObject ship;
    public float shipSpeed;

    GameObject[] stars;
    void Start()
    {
        CreateStars();

        CreatePlanet();

        CreateShip();
    }


    void Update()
    {
        StarsControl();

        PlanetControl();

        ShipControl();
    }

    void CreateStars()
    {
        stars = new GameObject[numOfStars];

        for (int i = 0; i < numOfStars; i++)
        {
            GameObject str = Instantiate(star, transform);

            str.transform.position = new Vector2(Random.Range(-12, 12), Random.Range(-6f, 7f));

            stars[i] = str;
        }
    }

    void StarsControl()
    {
        foreach (GameObject x in stars)
        {
            x.transform.Translate(Vector2.left * starSpeed * Time.deltaTime);

            if (x.transform.position.x < -11)
                x.transform.position = new Vector2(11, Random.Range(-6f, 7f));
        }
    }

    void CreatePlanet()
    {
        planets = Instantiate(planets, transform);
        planets.transform.position = new Vector2(2.5f, 1f);
    }

    void PlanetControl()
    {
        planets.transform.Translate( Vector2.left * planetSpeed * Time.deltaTime);

        if (planets.transform.position.x < -13)
            Destroy(planets);
    }

    void CreateShip()
    {
        ship = Instantiate(ship, transform);
        ship.transform.position = new Vector2(1.6f, -2.5f);
    }

    void ShipControl()
    {
        ship.transform.Translate(Vector2.left * shipSpeed * Time.deltaTime);

        if (planets.transform.position.x < -13)
            Destroy(ship);
    }
}
