using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{   
    //set Max walking speed
    public float maxSpeed;

    //allows you to control the rigidbody2d
    Rigidbody2D rb2d;

    //allow to change parameters to animation parameters.
    Animator anim;
    bool facingRight;
    // Use this for initialization

    //jump variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //shooting variables
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.3f;
    float nextFire = 0f;

    //SoundClip
    public AudioClip gunShot;
    AudioSource audioSource;

    //Player Health
    public int MaxHealth = 100;
    public int currentHealth;
    
    
     void Start()
    {

        //Getting components from the player
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is grounded and player presses space.
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            anim.SetBool("Grounded", grounded);
            rb2d.AddForce(new Vector2(0, jumpHeight));
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
            if(Input.GetAxisRaw("Jump") > 0) {
                fireBullet();
            }
        }
        if(currentHealth <=0) {
            Time.timeScale = 0;
        }
    }

    void FixedUpdate()
    {
        currentHealth = MaxHealth;
        //check if we are grounded and if player is falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("VertSpeed", rb2d.velocity.y);
        //checking player if he is using the left and right keys/A&D keys to move character
        float move = Input.GetAxis("Horizontal");

        //Manipulate Rigidbody to make it move to left and right.
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        //set animation to walk when he is moving
        anim.SetFloat("Speed", move);

        //Checking if player is walking to the left, Then flip it to the left same goes for the else statement but then to the right.
        if (move > 0 && facingRight)
        {
            flip();
        }
        else if (move < 0 && !facingRight)
        {
            flip();
        }
    }
    void flip()
    {
        //facingRight will be flipped
        facingRight = !facingRight;
        //Getting the scale from character
        Vector3 theScale = transform.localScale;
        //making the scale flip between 1 and -1
        theScale.x *= -1;
        //Flipping the scale to the opposite side when it's on it's recent scale (basically flipping the sprite on its mid axis.)
        transform.localScale = theScale;
    }
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            //checking and setting time between every bullet fired
            nextFire = Time.time + fireRate;
            if (!facingRight)
            {
                // making the bullet,
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                playGunShot();
            }
            else if (facingRight)
            {
                //making the bullet when it goes to the right flipping it due to the 180f as the Z axis.
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                //plays the gun shot sound.
                playGunShot();
            }
        }
    }
    void playGunShot()
    {
        //when having an audiosource linked to the GameObject this will make it play once.
        audioSource.PlayOneShot(gunShot, 0.7f);
    }
    void OnTriggerEnter2D(Collider2D c2d) {
        if(c2d.CompareTag("Enemy")) {
            currentHealth -= 1;
        }
    }
    
}
