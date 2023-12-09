using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveDown : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Transform target;
    void Update()
    {
        if (target.position.y >= gameObject.transform.position.y)
        {
            gameObject.transform.position = target.position;
            this.enabled = false;
            return;
        }
        transform.position -= new Vector3(0, speed*Time.deltaTime, 0);
    }

  
}
