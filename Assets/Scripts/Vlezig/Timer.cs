using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft = 30;
    [SerializeField] private GameObject text;
    private int displayTime;
    private RestartScript restartManager;

    private void Start()
    {
        restartManager = GameObject.FindGameObjectWithTag("LevelRestarter").GetComponent<RestartScript>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        displayTime = (int)timeLeft;
        text.GetComponent<Text>().text = displayTime.ToString();

        if (timeLeft <= 0)
        {
            restartManager.getCurrentIndex();
            SceneManager.LoadScene(2);
        }

    }
}
