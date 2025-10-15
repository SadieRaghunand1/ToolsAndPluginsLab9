using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    float speed = 0.5f;
    private PlayerControls playerControls;
    private float upperYBound = 15f;

    private void Start()
    {
        playerControls = FindAnyObjectByType<PlayerControls>();
    }

    private void FixedUpdate()
    {
        MoveUp();
    }
   
    void MoveUp()
    {
        rb.MovePosition(new Vector2(rb.position.x, rb.position.y + speed));
        if(rb.position.y > upperYBound)
        {
            playerControls.ReturnToPool(this.gameObject);
        }
    }

    
}
