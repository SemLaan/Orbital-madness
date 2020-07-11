using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{

    [SerializeField] private Vector2 initialVelocityDirection;
    [SerializeField] private float initialVelocityMagnitude;

    private Vector2 velocity;



    private void Awake()
    {

        velocity = initialVelocityDirection.normalized * initialVelocityMagnitude;
    }


    }
}
