using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    enum Shift
    {
        Player1,
        Player2
    }

    [SerializeField] private Shift playerShift;

    [SerializeField] private int[,] panel;
    [SerializeField] private GameObject[] columns;

    [SerializeField] private Text playerTurn;

    [SerializeField] private int winsPlayer1, winsPlayer2;

    public int[,] board = new int[6, 7];
    public GameObject[,] cardsInBoard = new GameObject[6, 7];

    [SerializeField] private Text winsPlayer1Text, winsPlayer2Text;

    [SerializeField] private ParticleSystem conffetiParticle;

    private void Start()
    {
        playerTurn.color = playerShift == Shift.Player1 ? Color.red : Color.blue;

    }

    public void Play(int column)
    {
        if (isCheckWin(1)|| isCheckWin(2))
        {
            return;
        }





        if (board[0,column]!=0)
        {
            return;
        }
        
        




        int yPos = 5;
		for (int i = 5; i >= 0; i--)
		{
			if (board[i, column] == 0)
			{
                yPos = i;
                break;
			}
		}

        ///Init
        GameObject card = ObjectPoolingManager.SharedInstance.GetFirsCard();
        card.SetActive(true);

        //set player
        card.GetComponent<CardStats>().PlayerStat = playerShift == Shift.Player1 ? CardStats.Players.Player1 : CardStats.Players.Player2;

        //target
        Transform[] transformsInColumn = columns[column].GetComponentsInChildren<Transform>();
        Transform target = transformsInColumn[yPos + 1];
        print(target);
        card.GetComponent<CardMoveDown>().target = target;

        //start position
        card.transform.position = transformsInColumn[1].position;


        //--------------------------------
        board[yPos,column]= playerShift == Shift.Player1? 1:2;
        cardsInBoard[yPos,column] = card;

        playerShift = playerShift == Shift.Player1 ? Shift.Player2 : Shift.Player1;

        playerTurn.text = playerShift == Shift.Player1 ? "Player 1" : "Player 2";
        playerTurn.color = playerShift == Shift.Player1 ? Color.red : Color.blue;

        //-------------------------
        winsPlayer1 += isCheckWin(1)? 1:0;
        winsPlayer1Text.text = winsPlayer1.ToString();

        winsPlayer2 += isCheckWin(2)? 1:0;
        winsPlayer2Text.text = winsPlayer2.ToString();

		if (isCheckWin(1)|| isCheckWin(2))
		{
            //ResetBoard();
            conffetiParticle.Play();
		}

        //PrintMatrix();
    }

	public void ResetBoard()
	{
        ObjectPoolingManager.SharedInstance.ResetCards();
        board= new int[6, 7];
    }

    public void ResetScores()
	{
        winsPlayer1 = 0;
        winsPlayer2 = 0;

        winsPlayer1Text.text = "0";
        winsPlayer2Text.text = "0";
    }

    public bool isCheckWin(int player)
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7-3; col++)
            {
                if (board[row, col] == player &&
                    board[row, col + 1] == player &&
                    board[row, col + 2] == player &&
                    board[row, col + 3] == player)
                {
                    cardsInBoard[row, col].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row, col+1].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row, col+2].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row, col+3].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;




                    return true;
                }
            }
        }
        
        
        for (int row = 0; row < 6-3; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (board[row, col] == player &&
                    board[row+1, col] == player &&
                    board[row+2, col] == player &&
                    board[row+3, col] == player)
                {
                    cardsInBoard[row, col].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row+ 1, col ].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 2, col].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 3, col].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                
                    return true;
                }
            }
        }
        
        
        for (int row = 0; row < 6-3; row++)
        {
            for (int col = 0; col < 7-3; col++)
            {
                if (board[row, col] == player &&
                    board[row+1, col+1] == player &&
                    board[row+2, col+2] == player &&
                    board[row+3, col+3] == player)
                {
                    cardsInBoard[row, col].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 1, col + 1].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 2, col + 2].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 3, col + 3].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;

                    return true;
                }
            
            
            
                if (board[row, col+3] == player &&
                    board[row+1, col+2] == player &&
                    board[row+2, col+1] == player &&
                    board[row+3, col] == player)
                {
                    cardsInBoard[row, col + 3].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 1, col + 2].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 2, col + 1].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    cardsInBoard[row + 3, col].GetComponent<CardStats>().PlayerStat = player == 1 ? CardStats.Players.Player1Win : CardStats.Players.Player2Win;
                    return true;
                }
            }
        }

        return false;
    }
    
    public void PrintMatrix()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                Debug.Log($"[{row}x,{col}y] = {board[row, col]}");
            }
        }
    }
    
}
