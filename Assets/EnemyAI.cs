using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour
{

    public Transform start;
    public Transform end;
    Rigidbody2D rb2d;
    public bool playerSpotted = false;
    public bool facingLeft = true;
    public bool grounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    float groundCheckRadius = 0.2f;
    public float speed;
    public Collider2D collidder;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (grounded)
        {
            if (transform.localRotation.z > 0)
            {
                //Adding force the the vector facing left 
                rb2d.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Force);
            }
            else
            {
                //Adding force the the vector facing right
                rb2d.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Force);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D c2d) {
        if(c2d.gameObject.CompareTag("Enemy")){
            Physics2D.IgnoreCollision(c2d.collider, collidder);
        }
    }
}