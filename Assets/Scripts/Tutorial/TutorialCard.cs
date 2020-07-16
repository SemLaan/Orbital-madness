using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCard : MonoBehaviour
{
    private SoundManager soundManager;
    [SerializeField] private AudioClip next;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void Finish()
    {
        soundManager.RandomizeSfx(next);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
