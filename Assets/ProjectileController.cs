using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
    //particle rigidbody 2d
    Rigidbody2D rb2d;
    //speed rocket
    public float rocketSpeed;

	// Use this for initialization
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z > 0) {
            //Adding force the the vector facing left 
            rb2d.AddForce(new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse);
        }else {
            //Adding force the the vector facing right
            rb2d.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //a public callable function for the bullet if the projectile hits something you can set the velocity to 0 so it stops
    public void removeForce() {
        rb2d.velocity = new Vector2(0, 0);
    }
}
