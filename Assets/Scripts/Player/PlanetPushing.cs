using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPushing : MonoBehaviour
{

    [Range(0, 100)]
    [SerializeField] private float playerForce = 1;
    [SerializeField] private Transform environmentParentObject = null;
    [SerializeField] private Transform lineObject = null;
    [Range(0, 1)]
    [SerializeField] private float bulletTimeSlowdown = 0;
    [SerializeField] private float zoomAmount = 0;

    private Controls controls;
    private bool leftMousePressedLastFrame = false;
    private bool rightMousePressedLastFrame = false;
    private Vector2 mousePositionLastFrame = Vector2.zero;
    private Collider2D targetPlanet;
    private new Transform camera;
    private Camera cameraComponent;

    private SoundManager soundManager;
    [SerializeField] private AudioClip pushSound = null;



    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("SoundManager") != null)
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").transform.GetComponent<SoundManager>();

        camera = Camera.main.transform;
        cameraComponent = camera.GetComponent<Camera>();
        controls = new Controls();
        controls.Enable();
    }


    private void PositionArrow(Vector2 mousePosition)
    {

        // Making the line the right length
        Vector3 lineScale = lineObject.localScale;
        lineScale.x = (targetPlanet.transform.position - (Vector3) mousePosition).magnitude;
        lineObject.localScale = lineScale;

        // Rotating the line
        Vector2 lineDirection = targetPlanet.transform.position - (Vector3) mousePosition;
        float lineAngle = Vector2.SignedAngle(Vector2.up, lineDirection);
        Vector3 currentRotation = lineObject.localRotation.eulerAngles;
        lineObject.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, lineAngle+90);

        // Setting the position
        lineObject.position = mousePosition;
    }


    private void Update()
    {

        // Camera zoom
        float scroll = controls.Gameplay.scrollWheel.ReadValue<float>();

        if (scroll > 0)
            cameraComponent.orthographicSize -= zoomAmount;
        else if (scroll < 0)
            cameraComponent.orthographicSize += zoomAmount;

        bool leftMousePressed = controls.Gameplay.leftMouse.ReadValue<float>() == 1;
        bool rightMousePressed = controls.Gameplay.rightMouse.ReadValue<float>() == 1;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(controls.Gameplay.mousePosition.ReadValue<Vector2>());

        // Camera panning
        if (rightMousePressed && rightMousePressedLastFrame)
        {

            environmentParentObject.position = environmentParentObject.position + (Vector3) mousePosition - (Vector3)mousePositionLastFrame;
        }


        // Player applying force to planets
        if (leftMousePressed && !leftMousePressedLastFrame)
        {

            targetPlanet = Physics2D.OverlapPoint(mousePosition);

            if (targetPlanet == null)
                return;
            else if (targetPlanet.tag == "tutorialcard")
            {

                targetPlanet.GetComponent<TutorialCard>().Finish();
                targetPlanet = null;
            } else if (targetPlanet.GetComponent<PlanetController>().immovable)
            {

                targetPlanet = null;
            } else
            {

                if (Time.timeScale != 0)
                    Time.timeScale = bulletTimeSlowdown;

                lineObject.gameObject.SetActive(true);
                PositionArrow(mousePosition);
            }
        } else if (leftMousePressed && leftMousePressedLastFrame)
        {

            if (targetPlanet != null)
                PositionArrow(mousePosition);
        } else if (!leftMousePressed && leftMousePressedLastFrame)
        {

            if (targetPlanet != null)
            {

                if (Time.timeScale != 0)
                    Time.timeScale = 1;

                Vector2 force = (Vector2)targetPlanet.transform.position - mousePosition;
                force *= playerForce;

                targetPlanet.GetComponent<PlanetController>().playerAcceleration = force;
                targetPlanet = null;

                if(soundManager != null)
                    soundManager.RandomizeSfx(pushSound);
            }

            lineObject.gameObject.SetActive(false);
        }

        leftMousePressedLastFrame = leftMousePressed;
        rightMousePressedLastFrame = rightMousePressed;
        mousePositionLastFrame = mousePosition;
    }

}
