using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform playerTransform;

    private Rigidbody2D rb;

    private int triggerCount = 0;

    private bool waitForPlayer = true;
    private bool canMove = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove && !waitForPlayer)
            Move((playerTransform.position - transform.position).normalized);
        else if (!waitForPlayer)
            rb.velocity = Vector2.zero;
    }

    private void Move(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            triggerCount++;

            if (triggerCount == 2)
            {
                canMove = false;
                waitForPlayer = false;
            }
            else if(triggerCount == 1)
                canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            triggerCount--;

            if (triggerCount == 1)
                canMove = true;
            else if(triggerCount == 0)
                canMove = false;
        }
            
    }
}
