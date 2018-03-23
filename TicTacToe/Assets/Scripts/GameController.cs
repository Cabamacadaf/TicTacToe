using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;
    private int moveCount;

    void Awake () {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons () {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide () {
        return playerSide;
    }

    public void EndTurn () {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            GameOver();
        }
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            GameOver();
        }

        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            GameOver();
        }

        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            GameOver();
        }
        if(moveCount >= 9) {
            SetGameOverText("It's a draw!");
        }
        ChangeSides();
    }

    void ChangeSides () {
        if (playerSide == "X") {
            playerSide = "O";
        }
        else {
            playerSide = "X";
        }
    }

    void SetGameOverText(string value) {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    void GameOver () {
        SetBoardInteractable(false);
        SetGameOverText(playerSide + " Wins!");
    }

    public void RestartGame () {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].text = "";
            SetBoardInteractable(true);
        }
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
    }

    void SetBoardInteractable (bool toggle) {
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}


