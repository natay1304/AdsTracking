﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;
using UnityEngine.UI;

public class FBInitialization : MonoBehaviour
{
    public static FBInitialization facebook;
    public Text deeplink;

    public ScriptableString url;

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
            //FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
            Debug.Log("awake not init");
        }
        else
        {
            FB.ActivateApp();            
            FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
            Debug.Log("awake active app");
        }

        DontDestroyOnLoad(this);
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("FB is initialized шnit call");
            FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FacebookEvent()
    {
        var tutParams = new Dictionary<string, object>();
        tutParams[AppEventParameterName.ContentID] = "tutorial_step_1";
        tutParams[AppEventParameterName.Description] = "First step in the tutorial, clicking the first button!";
        tutParams[AppEventParameterName.Success] = "1";

        FB.LogAppEvent(
           AppEventName.CompletedTutorial,
           parameters: tutParams
        );
    }

    void DeepLinkCallback(IAppLinkResult result)
    {
        Debug.Log("result " + result.Url);
        if (!String.IsNullOrEmpty(result.Url))
        {
            Debug.Log("scriptable " + url.value);
            url.value = result.Url;
            deeplink.text += result.Url;
            Debug.Log(deeplink.text);
        }
    }
}
