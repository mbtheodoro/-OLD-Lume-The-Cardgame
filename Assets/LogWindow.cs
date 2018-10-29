using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LogWindow : MonoBehaviour
{
    #region SINGLETON
    private static LogWindow _instance;
    public static LogWindow instance
    {
        get { return _instance; }
    }
    #endregion

    #region REFERENCES
    public Text text;
    #endregion

    #region METHODS
    public static void Log(string s)
    {
        instance.text.text += Environment.NewLine + s;
    }
    #endregion

    #region UNITY
    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;
        }
        else
            DestroyImmediate(gameObject);
    }
    #endregion
}
