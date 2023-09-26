using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
        {
            return (ballPos.y - paddlePos.y) / paddleHeight;
        }
        if(col.gameObject.name == "PaddleL")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(col.gameObject.name == "PaddleR")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
