using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnClickMatch()
    {
        SceneManager.LoadScene("DeckPicker");
    }

    public void OnClickTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
