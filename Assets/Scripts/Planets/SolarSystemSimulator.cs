using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemSimulator : MonoBehaviour
{

    [SerializeField] private SolarSystemController systemController = null;
    [SerializeField] private List<Transform> simulationDots = null;
    [SerializeField] private float timeSteps;
    [SerializeField] private int timestepsPerDot;




    public void Simulate(GameObject simulatingPlanet, Vector2 bonusAcceleration)
    { 

        List<PlanetController> planets = systemController.planets;
        List<PlanetData> planetLocations = systemController.planetLocations;
        List<Vector2> velocities = new List<Vector2>();
        //List<Vector2> positions = new List<Vector2>();

        for (int i = 0; i < planets.Count; i++)
        {

            velocities.Add(planets[i].velocity);
            //positions.Add(planets[i].transform.position);
        }

        for (int i = 0; i < simulationDots.Count * timestepsPerDot; i++)
        {

            List<Vector2> forces = new List<Vector2>();

            for (int j = 0; j < planets.Count; j++)
                forces.Add(new Vector2(0, 0));

            if (i == 0)
            {
                for (int j = 0; j < planets.Count; j++)
                {
                    if (planets[j].gameObject.GetInstanceID() == simulatingPlanet.GetInstanceID())
                    {
                        forces[j] += bonusAcceleration;
                        break;
                    }
                }
            }

            for (int j = 0; j < planets.Count; j++)
            {
                forces[j] = CalculateAcceleration(planetLocations, systemController.gravitationalConstant, planetLocations[j].position, planetLocations[j].mass, forces[j].x, forces[j].y);
            }

            // Update velocities and positions
            for (int j = 0; j < planets.Count; j++)
            {

                if (!planets[j].immovable)
                {
                    velocities[j] += forces[j] * timeSteps;
                    planetLocations[j] = new PlanetData((Vector2) planetLocations[j].position + velocities[j] * timeSteps, planetLocations[j].mass);
                }
            }

            if ((i + 1) % timestepsPerDot == 0)
            {
                for (int j = 0; j < planets.Count; j++)
                {

                    if (planets[j].gameObject.GetInstanceID() == simulatingPlanet.GetInstanceID())
                    {
                        print(i);
                        print(Mathf.FloorToInt(i / timestepsPerDot));
                        simulationDots[Mathf.FloorToInt(i / timestepsPerDot)].position = planetLocations[j].position;
                    }
                }
            }
        }
    }


    private Vector3 CalculateAcceleration(List<PlanetData> planetLocations, float gravitationalConstant, Vector2 currentPlanetPosition, float currentPlanetMass, float bx = 0, float by = 0)
    {

        Vector2 acceleration = Vector2.zero;
        acceleration += new Vector2(bx, by);

        foreach (PlanetData planet in planetLocations)
        {
            // Checking if its this planet
            if ((Vector2) planet.position == currentPlanetPosition)
                continue;

            Vector2 forceDirection = (planet.position - transform.position).normalized;
            float sqrDistance = (planet.position - transform.position).sqrMagnitude;
            acceleration += forceDirection * gravitationalConstant * (planet.mass * currentPlanetMass) / sqrDistance;
        }

        return acceleration;
    }
}
