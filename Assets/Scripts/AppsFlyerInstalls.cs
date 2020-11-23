using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppsFlyerInstalls : MonoBehaviour
{
    public Text installs;

    private void Start()
    {
        installs.text += "device ID " + AppsFlyer.getAppsFlyerId();
    }
}
