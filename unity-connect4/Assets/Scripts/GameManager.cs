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
    
    public int[,] board= new int[6,7];
    
    private void Start()
    {
        playerTurn.color = playerShift == Shift.Player1 ? Color.red : Color.blue;

    }

    public void Play(int column)
    {
        Transform[] transformsInColumn = columns[column].GetComponentsInChildren<Transform>();
        CardStats[] cardsInColumn = columns[column].GetComponentsInChildren<CardStats>();



        if (transformsInColumn.Length/2 <= cardsInColumn.Length)
        {
            return;
        }
        
        
        GameObject card = ObjectPoolingManager.SharedInstance.GetFirsCard();
        card.SetActive(true);
        card.GetComponent<CardStats>().PlayerStat =
            playerShift == Shift.Player1 ? CardStats.Players.Player1 : CardStats.Players.Player2;
        
        
        card.GetComponent<CardStats>().PlayerStat =
            playerShift == Shift.Player1 ? CardStats.Players.Player1 : CardStats.Players.Player2;

        playerShift = playerShift == Shift.Player1 ? Shift.Player2 : Shift.Player1;
        
        playerTurn.text = playerShift == Shift.Player1 ? "Player 1" : "Player 2";
        playerTurn.color = playerShift == Shift.Player1 ? Color.red : Color.blue;

        
        int posCardColumn = cardsInColumn.Length*2;

        
        Transform target=transformsInColumn[transformsInColumn.Length-1-posCardColumn];
        
        
        card.GetComponent<CardMoveDown>().target=target;
        
        Transform first = transformsInColumn[1].transform;
        card.transform.position = first.position;
        
        
        card.transform.SetParent(target.transform);
        
        board[transformsInColumn.Length - 2 - posCardColumn,column]= playerShift == Shift.Player2? 1:2;
        winsPlayer1+= isCheckWin(1)? 1:0;
        winsPlayer2+= isCheckWin(2)? 1:0;
        //PrintMatrix();
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
                    return true;
                }
            
            
            
                if (board[row, col+3] == player &&
                    board[row+1, col+2] == player &&
                    board[row+2, col+1] == player &&
                    board[row+3, col] == player)
                {
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
