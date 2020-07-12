using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetColission : MonoBehaviour
{
    private GameObject restartManager;
    private RestartScript resetter;
    private int gameOverIndex = 1;
    private SoundManager soundManager;
    [SerializeField] private AudioClip collisionSound;


    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("SoundManager") != null)
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

        if (GameObject.FindGameObjectWithTag("LevelRestarter") != null)
        {
            restartManager = GameObject.FindGameObjectWithTag("LevelRestarter");
            resetter = restartManager.GetComponent<RestartScript>();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            if(soundManager!=null)
                soundManager.PlaySingle(collisionSound);

            if(restartManager!=null)
                resetter.getCurrentIndex();

            SceneManager.LoadScene(gameOverIndex);
        }
    }

}
