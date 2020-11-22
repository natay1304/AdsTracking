using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOrientation : MonoBehaviour
{
    public bool autorotateToLandscapeRight, autorotateToLandscapeLeft, autorotateToPortrait, autorotateToPortraitUpsideDown;
    public ScreenOrientation orientation;

    void Start()
    {  
        Screen.orientation = orientation;

        Screen.autorotateToLandscapeLeft = autorotateToLandscapeLeft;
        Screen.autorotateToLandscapeRight = autorotateToLandscapeRight;
        Screen.autorotateToPortrait = autorotateToPortrait;
        Screen.autorotateToPortraitUpsideDown = autorotateToPortraitUpsideDown;
    }
}
