using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100.0f;
    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "racket")
        {
            float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
