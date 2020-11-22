using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebViewLink : MonoBehaviour
{
    public Text webviewLink;
    public ScriptableString url;

    private void Start()
    {
        webviewLink.text += url.value;
    }
}
