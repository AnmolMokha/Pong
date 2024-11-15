using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D ball;

    private void Update()
    {
        // Ball is moving towards the computer paddle
        if(ball.velocity.x > 0.0f)
        {
            // Ball is above the computer paddle
            if(ball.position.y > this.transform.position.y)
            {
                // Move up
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            // Ball is below the computer paddle
            else if(ball.position.y < this.transform.position.y)
            {
                // Move down
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
        // Ball is moving away from the computer paddle
        else if(ball.velocity.x < 0.0f)
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            if (transform.position.y > 0f)
            {
                // Move down towards the center
                transform.position += Vector3.down * speed * Time.deltaTime;

                // Snap to the center if close to it
                if (transform.position.y < 0.1)
                {
                    transform.position = new Vector3(this.transform.position.x, 0f);
                }
            }
            else if (transform.position.y < 0f)
            {
                // Move up towards the center
                transform.position += Vector3.up * speed * Time.deltaTime;

                // Snap to the center if close to it
                if (transform.position.y > -0.1)
                {
                    transform.position = new Vector3(this.transform.position.x, 0f);
                }
            }
        }

        ClampMovement();
    }
}
