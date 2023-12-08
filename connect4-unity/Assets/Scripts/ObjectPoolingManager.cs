using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] private int totalCards;
    [SerializeField] private List<GameObject> cards;
    [SerializeField] private GameObject player;

    public static ObjectPoolingManager SharedInstance;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            Destroy(SharedInstance);
        }

        SharedInstance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalCards; i++)
        {
            GameObject card= Instantiate(player,transform.position,quaternion.identity,transform);
            cards.Add(card);
            card.SetActive(false);
        }
    }

    public GameObject GetFirsCard()
    {
        GameObject cardResult= cards[0];
        cards.Remove(cardResult);
        return cardResult;

    }
}
