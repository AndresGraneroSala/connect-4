using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] private int totalCards;
    [HideInInspector] public List<GameObject> cards;
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

    public void ResetCards()
	{

		foreach (var card in cards)
		{
            card.SetActive(false);
            card.GetComponent<CardMoveDown>().enabled = true;
		}

	}

    public GameObject GetFirsCard()
    {
		for (int i = 0; i < cards.Count; i++)
		{
			if (!cards[i].activeSelf)
			{
                return cards[i];
			}
		}
        return cards[0];

    }
}
