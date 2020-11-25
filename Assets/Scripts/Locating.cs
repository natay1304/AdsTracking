﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using AppsFlyerSDK;
using Facebook.Unity;

public class Locating : MonoBehaviour
{
    public Button button;

    [SerializeField]
    private Text _textState;

    void Start()
    {
        button.onClick.AddListener(Handler);
    }

    private void Handler()
    {
        StartCoroutine("DetectCountry");
    }

    IEnumerator DetectCountry()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://extreme-ip-lookup.com/json");
        request.chunkedTransfer = false;
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            _textState.text = "error : " + request.error;
        }
        else
        {
            if (request.isDone)
            {
                Country res = JsonUtility.FromJson<Country>(request.downloadHandler.text);
                _textState.text = res.country;
                Debug.Log(res.country);
                OpenNextScene(res);
            }
        }
    }

    private void OpenNextScene(Country res)
    {
        if (res.countryCode.ToLower() == "ru")
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            SceneManager.LoadScene(1);
            AppsFlyer.sendEvent("webview-srarted", null);
            FB.LogAppEvent("webview-srarted");           
        }
        else
        {
            SceneManager.LoadScene(2);
            AppsFlyer.sendEvent("wrapper", null);
            FB.LogAppEvent("wrapper");
            Debug.Log(res.countryCode);
        }
    }    
}
