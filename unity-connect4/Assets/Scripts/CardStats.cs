using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStats : MonoBehaviour
{
    public enum Players
    {
        Player1,Player2,Player1Win,Player2Win
    }

    [SerializeField] private Players playerStat;
    [SerializeField] private Sprite Red, Blue,RedWin,BlueWin;
    [SerializeField] private Image img;
    
    
    public Players PlayerStat
    {
        get => playerStat;
        set
        {
			switch (value)
			{
                case Players.Player1:
                    img.sprite = Red;
                    break;

                case Players.Player2:
                    img.sprite = Blue;
                    break;

                case Players.Player1Win:
                    img.sprite = RedWin;
                    break;

                case Players.Player2Win:
                    img.sprite = BlueWin;
                    break;



                default:   break;

			}

			playerStat = value;
        }
    }

    
}
