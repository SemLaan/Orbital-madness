using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCap : MonoBehaviour
{
    [SerializeField] private float xmin=0, xmax=0, ymin=0, ymax=0;


    private void LateUpdate()
    {
        if (transform.position.x > xmax)
            transform.position = new Vector2(xmax, transform.position.y);

        if (transform.position.x < xmin)
            transform.position = new Vector2(xmin, transform.position.y);

        if (transform.position.y > ymax)
            transform.position = new Vector2(transform.position.x, ymax);

        if (transform.position.y < ymin)
            transform.position = new Vector2(transform.position.x, ymin);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 0, 0.2f);
        Gizmos.DrawCube(new Vector2((xmin + xmax) / 2, (ymin + ymax) / 2), new Vector2(xmax - xmin, ymax - ymin));
    }

}
