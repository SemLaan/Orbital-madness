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

    List<Transform> planets; // All the planet objects
    List<PlanetData> planetLocations; // Updates every fixed update with all the locations and masses of the planets



    private void Awake()
    {

        planets = new List<Transform>();
        planetLocations = new List<PlanetData>();

        foreach (Transform planet in transform)
        {

            planets.Add(planet);
            planetLocations.Add(
                new PlanetData(planet.position, 
                        planet.GetComponent<PlanetController>().mass));
        }
    }



    private void FixedUpdate()
    {

        for (int i = 0; i < planets.Count; i++)
        {

            planetLocations[i] = new PlanetData(planets[i].position, planetLocations[i].mass);
        }

        //TODO: call planets update velocity functions
        //TODO: call planets update position functions
    }
}
