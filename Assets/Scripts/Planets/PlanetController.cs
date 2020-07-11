using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{

    [SerializeField] private Vector2 initialVelocity;

    private Vector2 velocity;



    private void Awake()
    {

        velocity = initialVelocity;
    }
}
