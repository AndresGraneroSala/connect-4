using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveDown : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Transform target;
    [SerializeField] private int initResolutionY=1080;
    [SerializeField] private int actualResolutionY;


	private void Start()
	{
        actualResolutionY = Screen.height;
        speed *= (float)initResolutionY / actualResolutionY;
	}

	void Update()
    {




        if (target.transform.position.y >= gameObject.transform.position.y)
        {


            gameObject.transform.position = target.position;
            this.enabled = false;
            return;
        }
        transform.position -= new Vector3(0, speed*Time.deltaTime, 0);
    }

  
}
