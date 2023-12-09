using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public enum Players
    {
        Player1,Player2,Player1Win,Player2Win
    }

    [SerializeField] private Players playerStat;
    [SerializeField] private Sprite Red, Blue,RedWin,BlueWin;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    
    public Players PlayerStat
    {
        get => playerStat;
        set
        {
			switch (value)
			{
                case Players.Player1:
                spriteRenderer.sprite = Red;
                    break;

                case Players.Player2:
                    spriteRenderer.sprite = Blue;
                    break;

                case Players.Player1Win:
                    spriteRenderer.sprite = RedWin;
                    break;

                case Players.Player2Win:
                    spriteRenderer.sprite = BlueWin;
                    break;



                default:   break;

			}

			playerStat = value;
        }
    }

    
}
