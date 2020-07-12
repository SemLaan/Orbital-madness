using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 30;
    [SerializeField] private GameObject text;
    private int displayTime;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        displayTime = (int)timeLeft;
        text.GetComponent<Text>().text = displayTime.ToString();
    }
}
