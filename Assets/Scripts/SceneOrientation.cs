using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOrientation : MonoBehaviour
{
    public bool landscapeOrientation;

    void Start()
    {
        if(landscapeOrientation)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft; 
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToLandscapeLeft = true;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}
