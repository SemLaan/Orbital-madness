using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft = 30;
    [SerializeField] private GameObject text = null;
    private int displayTime;
    private RestartScript restartManager = null;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelRestarter"))
            restartManager = GameObject.FindGameObjectWithTag("LevelRestarter").GetComponent<RestartScript>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        displayTime = (int)timeLeft;
        text.GetComponent<Text>().text = displayTime.ToString();

        if (timeLeft <= 0)
        {
            if (restartManager != null)
            {
                restartManager.getCurrentIndex();
                SceneManager.LoadScene(2);
            }
        }

    }
}
