using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public GameObject winPopUp;
    public TextMeshProUGUI winnerText;

    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;


    void Start()
    {
        UpdateUI();
        winPopUp.SetActive(false);
    }

    public void AddPoint(string pizzaTag)
    {
        if (pizzaTag == "Player1Pizza")
            player1Score++;

        if (pizzaTag == "Player2Pizza")
            player2Score++;

        UpdateUI();
    }

    void UpdateUI()
    {
        p1Text.text = "Score: " + player1Score;
        p2Text.text = "Score: " + player2Score;
    }

    public void endGame()
    {
        winPopUp.SetActive(true);
        if (player1Score > player2Score) { 
            winnerText.text = "Player 1 Wins!"; }

        else if (player2Score > player1Score) 
            { winnerText.text = "Player 2 Wins!"; } 
        
        else { winnerText.text = "It's a Draw!"; }

        Debug.Log("Game Over triggered in GameManager");
    }
}
