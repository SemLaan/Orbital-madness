using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPushing : MonoBehaviour
{

    [Range(0, 100)]
    [SerializeField] private float playerForce = 1;
    [SerializeField] private Transform environmentParentObject = null;

    private Controls controls;
    private bool leftMousePressedLastFrame = false;
    private bool rightMousePressedLastFrame = false;
    private Vector2 mousePositionLastFrame = Vector2.zero;
    private Collider2D targetPlanet;
    private new Transform camera;



    private void Awake()
    {

        camera = Camera.main.transform;
        controls = new Controls();
        controls.Enable();
    }


    private void Update()
    {

        bool leftMousePressed = controls.Gameplay.leftMouse.ReadValue<float>() == 1;
        bool rightMousePressed = controls.Gameplay.rightMouse.ReadValue<float>() == 1;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(controls.Gameplay.mousePosition.ReadValue<Vector2>());

        // Player panning
        if (rightMousePressed && rightMousePressedLastFrame)
        {

            environmentParentObject.position = environmentParentObject.position + (Vector3) mousePosition - (Vector3)mousePositionLastFrame;
        }


        // Player applying force to planets
        if (leftMousePressed && !leftMousePressedLastFrame)
        {

            targetPlanet = Physics2D.OverlapPoint(mousePosition);
        } else if (leftMousePressed && leftMousePressedLastFrame)
        {

            if (targetPlanet != null)
            {

                //TODO: draw arrow
            }
        } else if (!leftMousePressed && leftMousePressedLastFrame)
        {

            if (targetPlanet != null)
            {

                Vector2 force = (Vector2)targetPlanet.transform.position - mousePosition;
                force *= playerForce;

                targetPlanet.GetComponent<PlanetController>().playerAcceleration = force;
                targetPlanet = null;
            }
        }

        leftMousePressedLastFrame = leftMousePressed;
        rightMousePressedLastFrame = rightMousePressed;
        mousePositionLastFrame = mousePosition;
    }
}
