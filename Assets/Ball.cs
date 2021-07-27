using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    public GameObject player;
    public GameObject enamy;
    private int condition = 0;

    public static Action<GameObject> damage = delegate { };
    public static Action<GameObject> health = delegate { };
    public static Action<GameObject> increase = delegate { };

    void Start()
    {
        Triger.goal += Triger_Goal;
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }

    private void Triger_Goal()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.name == player.name)
        {
            switch (condition)
            {
                case 1://Лечение
                    health(collision.gameObject);
                    break;
                case 2://Домаг
                    damage(collision.gameObject);
                    break;
                case 3://Увеличение
                    increase(collision.gameObject);
                    break;
            }

            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.name == enamy.name)
        {
            switch(condition)
            {
                case 1://Лечение
                health(collision.gameObject);
                break;
                case 2://Домаг
                damage(collision.gameObject);
                break;
                case 3://Увеличение
                increase(collision.gameObject);
                break;
            }
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        condition = Random.Range(0, 4);
        


        var ball = gameObject.GetComponent<Renderer>();

        switch (condition)
        {
            case 0:
                ball.material.color = Color.white;
                break;
            case 1:
                ball.material.color = Color.green;//лечение
                break;
            case 2:
                ball.material.color = Color.red;//Домаг
                break;
            case 3:
                ball.material.color = Color.blue;//Увеличение
                break;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}