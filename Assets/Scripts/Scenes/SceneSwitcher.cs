﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void playGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
