using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeckPicker : MonoBehaviour
{
    public Text playerText;

    private bool player1Picked;

    public void OnClickEarth()
    {
        if(!player1Picked)
        {
            player1Picked = true;
            Defines.player1nation = Nation.EARTH;
            playerText.text = "PLAYER TWO";
        }
        else
        {
            Defines.player2nation = Nation.EARTH;
            SceneManager.LoadScene("Match");
        }
    }

    public void OnClickFire()
    {
        if (!player1Picked)
        {
            player1Picked = true;
            Defines.player1nation = Nation.FIRE;
            playerText.text = "PLAYER TWO";
        }
        else
        {
            Defines.player2nation = Nation.FIRE;
            SceneManager.LoadScene("Match");
        }
    }

    public void Back()
    {
        if (player1Picked)
        {
            player1Picked = false;
            playerText.text = "PLAYER ONE";
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Start()
    {
        player1Picked = false;
    }
}
