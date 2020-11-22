using UnityEngine;
using Facebook.Unity;
using AppsFlyerSDK;

public class SentAppStartEvent : MonoBehaviour
{    
    private void Start()
    {
        FB.LogAppEvent("i-am-working");
        AppsFlyer.sendEvent("i-am-working", null);
    }
}
