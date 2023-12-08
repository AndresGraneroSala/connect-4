using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public enum Players
    {
        Player1,Player2
    }

    [SerializeField] private Players playerStat;
    [SerializeField] private Sprite Red, Blue;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    
    public Players PlayerStat
    {
        get => playerStat;
        set
        {
            spriteRenderer.sprite = playerStat == Players.Player1? Red: Blue;
            playerStat = value;
        }
    }

    void Start()
    {
        PlayerStat = Players.Player2;
    }
    
}
