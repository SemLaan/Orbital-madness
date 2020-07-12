using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{

    [SerializeField] private Vector2 initialVelocityDirection = Vector2.one;
    [SerializeField] private float initialVelocityMagnitude = 1;
    public bool immovable = false;
    public float mass;

    [HideInInspector] public Vector2 playerAcceleration;
    [HideInInspector] public Vector2 velocity;



    private void Awake()
    {

        velocity = initialVelocityDirection.normalized * initialVelocityMagnitude;
    }


    public Vector3 CalculateAcceleration(List<PlanetData> planetLocations, float gravitationalConstant, float bx=0, float by=0)
    {

        Vector2 acceleration = Vector2.zero;
        acceleration += playerAcceleration;
        acceleration += new Vector2(bx, by);
        playerAcceleration = Vector2.zero;

        foreach (PlanetData planet in planetLocations)
        {
            // Checking if its this planet
            if (planet.position == transform.position)
                continue;

            Vector2 forceDirection = (planet.position - transform.position).normalized;
            float sqrDistance = (planet.position - transform.position).sqrMagnitude;
            acceleration += forceDirection * gravitationalConstant * (planet.mass * mass) / sqrDistance;
        }

        return acceleration;
    }


    public void UpdateVelocityAndPosition(Vector2 acceleration)
    {

        if (!immovable)
        {

            velocity += acceleration * Time.fixedDeltaTime;
            transform.position = transform.position + (Vector3)velocity * Time.fixedDeltaTime;
        }
    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;

        if (immovable)
            return;
        else if (velocity == Vector2.zero)
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)initialVelocityDirection.normalized * initialVelocityMagnitude);
        else
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)velocity);
    }
}
