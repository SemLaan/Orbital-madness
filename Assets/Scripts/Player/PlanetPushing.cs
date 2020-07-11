using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPushing : MonoBehaviour
{

    private Controls controls;
    private bool leftMousePressedLastFrame = false;
    


    private void Awake()
    {

        controls = new Controls();
        controls.Enable();
    }


    private void Update()
    {

        bool leftMousePressed = controls.Gameplay.leftMouse.ReadValue<float>() == 1;
        Vector2 mousePosition = controls.Gameplay.mousePosition.ReadValue<Vector2>();

        if (leftMousePressed && !leftMousePressedLastFrame)
        {

            Collider2D collision = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(mousePosition));
            Destroy(collision.gameObject);
        }

        leftMousePressedLastFrame = leftMousePressed;
    }
}
