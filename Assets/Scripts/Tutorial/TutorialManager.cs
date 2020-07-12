using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private float launchPlanet = 0, pan = 0, timer = 0;
    [SerializeField] private GameObject launchPlanetCard = null, panningCard = null, timerCard = null;
    [SerializeField] private Timer gameTimer = null;

    private bool activatedLaunchPlanet = false, activatedPanningCard = false, activatedTimerCard = false;

    
    
    private void Update()
    {

        if (gameTimer.timeLeft <= launchPlanet && !activatedLaunchPlanet)
            launchPlanetCard.SetActive(true);

        if (gameTimer.timeLeft <= pan && !activatedPanningCard)
            panningCard.SetActive(true);

        if (gameTimer.timeLeft <= timer && !activatedTimerCard)
            timerCard.SetActive(true);
    }
}
