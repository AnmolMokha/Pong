using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float speed;
    [SerializeField] private float topBound;
    [SerializeField] private float bottomBound;

    public void ResetPosition()
    {
        Vector2 direction = Vector2.zero;
        transform.position = new Vector3(transform.position.x, 0f);
    }

    protected void ClampMovement()
    {
        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, 0f);
        }
        else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, bottomBound, 0f);
        }
    }
}
