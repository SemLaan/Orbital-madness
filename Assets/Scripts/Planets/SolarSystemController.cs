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

    List<GameObject> planets; // All the planet objects
    List<PlanetData> planetLocations; // Updates every fixed update with all the locations and masses of the planets


    private void Awake()
    {
        
        //TODO: grab children
    }



    private void FixedUpdate()
    {
        
        //TODO: make list of planet data
        //TODO: call planets update velocity functions
        //TODO: call planets update position functions
    }
}
