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

    [SerializeField] private AudioClip collisionSound = null;
    [SerializeField] private GameObject explosion = null;


    [SerializeField] private float timeLeft = 2;
    private SpriteRenderer spriteRenderer;

    private bool countDown = false;
    private Timer timer;

    private int timeOfExplosion;
    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (GameObject.FindGameObjectWithTag("SoundManager") != null)
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

        if (GameObject.FindGameObjectWithTag("LevelRestarter") != null)
        {
            restartManager = GameObject.FindGameObjectWithTag("LevelRestarter");
            resetter = restartManager.GetComponent<RestartScript>();
        }

    }

    private void Update()
    {
        if (countDown)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
                SceneManager.LoadScene(gameOverIndex);
            timer.timeLeft = timeOfExplosion;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            timeOfExplosion = (int)timer.timeLeft;
            spriteRenderer.enabled = false;
            
            Vector3 explosionPosition = (collision.transform.position + transform.position)/2;
            Instantiate(explosion, explosionPosition, Quaternion.identity);

            if(soundManager!=null)
                soundManager.PlaySingle(collisionSound);

            if(restartManager!=null)
                resetter.getCurrentIndex();

            countDown = true;
            collider.enabled = false;
        }
    }
}
