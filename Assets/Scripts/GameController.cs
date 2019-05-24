using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{

	public Image panel;
	public Text text;

}

[System.Serializable]
public class PlayerColor
{

	public Color panelColor;
	public Color textColor;

}
public class GameController : MonoBehaviour {

	public Text[] buttonList;
	private string playerSide;

	public GameObject gameOverPanel;
	public Text gameOverText;

	private int moveCount;

	public GameObject restartButton;

	public Player playerX;
	public Player playerO;
	public PlayerColor activitePlayerColor;
	public PlayerColor inactivePlayerColor;

	public GameObject aboutMeButton;
	public GameObject aboutMePanel;
	void Awake()
	{
		gameOverPanel.SetActive (false);
		restartButton.SetActive (false);
		aboutMePanel.SetActive (false);
		SetGameControllerReferenceOnButtons ();
		playerSide = "X";
		moveCount = 0;

		SetPlayerColors (playerX, playerO);

	}
	void SetGameControllerReferenceOnButtons()
	{

		for (int i = 0; i < buttonList.Length; i++) 
		{

			buttonList [i].GetComponentInParent<GridSpace> ().SetGameControllerReference (this);

		}


	}

	public string GetPlayerSide()
	{
		return playerSide;
	}
	public void EndTurn()
	{
		moveCount++;
		if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
		{
		
			gameOver ();

		}
		else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
		{

			gameOver ();

		}
		else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{

			gameOver ();

		}
		else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
		{

			gameOver ();

		}
		else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
		{

			gameOver ();

		}
		else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
		{

			gameOver ();

		}
		else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{

			gameOver ();

		}
		else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
		{

			gameOver ();

		}

		else if(moveCount>=9) 
		{
			SetGameOverText( "Berabere!");
		}
		else
		changeSides ();
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer)
	{
	
		newPlayer.panel.color = activitePlayerColor.panelColor;
		newPlayer.text.color = activitePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;

	}
	void gameOver()
	{
		
		SetBoardInteractable (false);
		SetGameOverText( playerSide + "  Kazandı");


	}

	void changeSides()
	{

		playerSide = (playerSide == "X") ? "O" : "X";

		if (playerSide == "X")
		{
			SetPlayerColors (playerX, playerO);
		} 
		else
		{
			SetPlayerColors (playerO, playerX);	
		}
	}

	void SetGameOverText(string value)
	{
		restartButton.SetActive (true);
		gameOverPanel.SetActive (true);
		gameOverText.text = value;


	}

	public void RestartGame()
	{
		playerSide ="X";
		moveCount = 0;
		gameOverPanel.SetActive (false);

		SetBoardInteractable (true);

		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].text = "";
		}
		SetPlayerColors (playerX, playerO);
		restartButton.SetActive (false);
	}


	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].GetComponentInParent<Button> ().interactable =  toggle;

		}
	}

	public void AboutMe()
	{
		aboutMePanel.SetActive (true);
	}

	public void AboutMeCancel()
	{
		aboutMePanel.SetActive (false);
	}
}
