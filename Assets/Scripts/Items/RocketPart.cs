using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPart : MonoBehaviour
{
    public Vector2 direction; 
    public float speed = 5f;  
    private Vector2 position;

    public void Initialize(Vector2 startPos, Vector2 moveDirection)
    {
        position = startPos;
        direction = moveDirection;
    }

    public void Move()
    {
        position += direction * speed * Time.deltaTime;
    }

    

}

