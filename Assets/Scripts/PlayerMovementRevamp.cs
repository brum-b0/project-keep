using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRevamp : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveH = (Input.GetAxis("Horizontal") * moveSpeed) ;
        moveV = (Input.GetAxis("Vertical") * moveSpeed)/2.0f;
        rb.velocity = new Vector2(moveH, moveV).normalized;

        Vector2 direction = new Vector2(moveH, moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }



}
