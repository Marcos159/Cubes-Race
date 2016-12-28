using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scores : MonoBehaviour {
    public int player1Score=0;
    public int player2Score = 0;
    public int player3Score = 0;
    public int player4Score = 0;
    public int maxScore=5;

    public GameObject canvasWinner;
    public Text player1Txt;
    public Text player2Txt;
    public Text player3Txt;
    public Text player4Txt;

    public Text winnerTxt;

    void Start()
    {
        
    }

    public void onClick()
    {
        SceneManager.UnloadScene("Escena");
        SceneManager.LoadScene("Escena");
    }

    // Update is called once per frame
    void Update () {
        player1Txt.text = "Player1: " + player1Score + "/5";
        player2Txt.text = "Player2: " + player2Score + "/5";
        player3Txt.text = "Player3: " + player3Score + "/5";
        player4Txt.text = "Player4: " + player4Score + "/5";
        if (player1Score>=maxScore)
        {
            canvasWinner.SetActive(true);
            winnerTxt.text = "Player1";
            winnerTxt.color = new Color(188.0f/ 255.0f, 29.0f / 255.0f, 29.0f / 255.0f);
        }
        else if (player2Score >= maxScore)
        {
            canvasWinner.SetActive(true);
            winnerTxt.text = "Player2";
            winnerTxt.color = new Color(55.0f / 255.0f, 92.0f / 255.0f, 156.0f / 255.0f);
        }
        else if (player3Score >= maxScore)
        {
            canvasWinner.SetActive(true);
            winnerTxt.text = "Player3";
            winnerTxt.color = new Color(218.0f / 255.0f, 212.0f / 255.0f, 125.0f / 255.0f);
        }
        else if (player4Score >= maxScore)
        {
            canvasWinner.SetActive(true);
            winnerTxt.text = "Player4";
            winnerTxt.color = new Color(92.0f / 255.0f, 148.0f / 255.0f, 67.0f / 255.0f);
        }
    }
}
