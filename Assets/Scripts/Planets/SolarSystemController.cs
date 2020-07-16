using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Struct for telling the planets where all the other planets are
public struct PlanetData 
{

    public Vector3 position;
    public float mass;

    public PlanetData(Vector3 position, float mass)
    {

        this.position = position;
        this.mass = mass;
    }
}


public class SolarSystemController : MonoBehaviour
{

    [SerializeField] private float gravitationalConstant = 0;

    List<PlanetController> planets; // All the planet objects
    List<PlanetData> planetLocations; // Updates every fixed update with all the locations and masses of the planets



    private void Awake()
    {

        planets = new List<PlanetController>();
        planetLocations = new List<PlanetData>();

        foreach (Transform planet in transform)
        {

            planets.Add(planet.GetComponent<PlanetController>());
            planetLocations.Add(
                new PlanetData(planet.position, 
                        planet.GetComponent<PlanetController>().mass));
        }
    }



    private void FixedUpdate()
    {

        for (int i = 0; i < planets.Count; i++)
        {

            planetLocations[i] = new PlanetData(planets[i].transform.position, planetLocations[i].mass);
        }

        Vector3[] accelerations = new Vector3[planets.Count];

        for (int i = 0; i < planets.Count; i++)
        {

            accelerations[i] = planets[i].CalculateAcceleration(planetLocations, gravitationalConstant);
        }

        for (int i = 0; i < planets.Count; i++)
        {

            planets[i].UpdateVelocityAndPosition(accelerations[i]);
        }
    }
}
