using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameWindow : MonoBehaviour
{
    public RectTransform thisRect;
    //public Button closeButton;
    public Text text;

    public float moveDuration;
    public float activatedPosY;
    private float targetPosY;

    private bool move;
    private float timeMoving;
    private float initialPosY;

    void FixedUpdate()
    {
        if (move)
        {
            timeMoving += Time.fixedDeltaTime;
            if (Mathf.Abs(transform.position.y - targetPosY) < 0.01f)
            {
                thisRect.anchoredPosition = new Vector2(thisRect.anchoredPosition.x, targetPosY);
                //transform.position = new Vector3(transform.position.x, targetPosY, transform.position.z);
                move = false;
            }
            else
            {
                float t = timeMoving / moveDuration - 1;
                float dh = targetPosY - initialPosY;
                thisRect.anchoredPosition = new Vector2(thisRect.anchoredPosition.x, dh * (t * t * t * t * t + 1) + initialPosY);
                //transform.position = new Vector3(transform.position.x, dh * (t * t * t * t * t + 1) + initialPosY, transform.position.z);
            }
        }
    }

    public void OnGameEnd(PlayerInfo winner, Nation nation)
    {
        string newtext = string.Empty;

        if (winner == PlayerInfo.PLAYER1)
            newtext += "PLAYER ONE LEAD ";
        else //winner == PlayerInfo.PLAYER2
            newtext += "PLAYER TWO LEAD ";

        if (nation == Nation.EARTH)
            newtext += "THE EARTH KINGDOM ";
        else if(nation == Nation.FIRE)
            newtext += "THE FIRE EMPIRE ";

        newtext += text.text;

        text.text = newtext;

        Activate();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Activate()
    {
        targetPosY = activatedPosY;
        initialPosY = thisRect.anchoredPosition.y;
        timeMoving = 0.0f;

        move = true;
    }

    public void Deactivate()
    {
        targetPosY = initialPosY;
        initialPosY = thisRect.anchoredPosition.y;
        timeMoving = 0.0f;

        move = true;
    }
}