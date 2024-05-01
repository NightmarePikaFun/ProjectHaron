using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    private Rigidbody2D rb;
    private float speedX, speedY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HaronLibrary.playerCanMove)
        {
            speedX = Input.GetAxis("Horizontal");
            speedY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(speedX, speedY).normalized * speed;
        }
    }
}
