using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.talking) // Can't move or fire during dialogue
        {
            Vector2 move = Vector2.zero;
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            Vector2 normalizedMove = move.normalized;
            if (normalizedMove.x > move.x || normalizedMove.y > move.y)
                move = normalizedMove;
            move *= moveSpeed;

            rb.velocity = move;

            if (Firing())
            {
                // Shooty mechanics here.
            }
        }
    }

    public bool Firing()
    {
        return Input.GetButton("Fire") || 0 < Input.GetAxisRaw("Fire");
    }
}
