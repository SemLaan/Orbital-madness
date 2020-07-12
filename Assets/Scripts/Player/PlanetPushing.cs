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

    private SoundManager soundManager;
    [SerializeField] private AudioClip pushSound;

    [SerializeField] private float xmin, xmax, ymin, ymax;


    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("SoundManager") != null)
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").transform.GetComponent<SoundManager>();

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

                if(soundManager != null)
                    soundManager.PlaySingle(pushSound);
            }
        }

        leftMousePressedLastFrame = leftMousePressed;
        rightMousePressedLastFrame = rightMousePressed;
        mousePositionLastFrame = mousePosition;
    }


    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector2((Mathf.Abs(xmin))+xmax,(Mathf.Abs(ymin))+ymax));
    }

}
