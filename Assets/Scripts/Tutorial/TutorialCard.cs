using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCard : MonoBehaviour
{
    
    public void Finish()
    {

        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
