using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;


public class EnemyBehavior : MonoBehaviour, IEnemy
{
    private PlayerControls playerControls;
    [SerializeField] private Rigidbody2D rb;

    bool moveRight;
    float leftBound = -10;
    float rightBound = 10;
    float speed = 0.2f;
    private int points;
    public delegate void Event_OnHit(int points);
    Event_OnHit onHit;

  
    // Start is called before the first frame update
    void Start()
    {
        playerControls = FindAnyObjectByType<PlayerControls>();
        onHit += playerControls.Callback_IncreaseScore;
        onHit += _ => OnHit();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBwPts();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KillEnemy(collision);
    }
    void KillEnemy(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            playerControls.ReturnToPool(collision.gameObject);
            onHit?.Invoke(points);

        }
    }

    public void OnHit()
    {
        
        Destroy(this.gameObject);
    }

    private void MoveBwPts()
    {

        if (rb.position.x <= leftBound || rb.position.x >= rightBound)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            rb.MovePosition(new Vector2(rb.position.x + speed, rb.position.y));
        }
        else
        {
            rb.MovePosition(new Vector2(rb.position.x + -speed, rb.position.y));
        }

    }
    public void SetupFromData(Enemy enemyData)
    {
        speed = enemyData.Speed * 0.1f;
        points = enemyData.Points;

        transform.localScale = Vector3.one * enemyData.Scale;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        sr.color = enemyData.Color;
    }

    public Enemy GetData()
    {
        Enemy newEnemy = new Enemy();  
        newEnemy.Speed = (int)speed;
        newEnemy.Scale = transform.localScale.x;
        newEnemy.Color = GetComponent<SpriteRenderer>().material.color;
        return newEnemy;
    }

    
}
