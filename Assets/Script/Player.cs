using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 3;
	public float Speed = 50f;
	public float jumpPower = 550f;

	public bool grounded;
	public bool sprinting;
	public bool shooting;
	public AnimationClip punchAnim;
	public Animation animationCall;


	private Rigidbody2D rb2d;
	private Animator anim;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	
	}

	void Update () {
	
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool ("Sprinting", sprinting);


		if (Input.GetAxis ("Horizontal") < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (Input.GetAxis ("Horizontal") >= 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if(Input.GetButton("Jump") && grounded){
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
				jumpPower = 700f;
				rb2d.AddForce (Vector2.up * jumpPower );
			}else{
				rb2d.AddForce (Vector2.up * jumpPower);
			}

		}
		if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) && grounded) {
			maxSpeed = 20;
			sprinting = true;
		} else {
			maxSpeed = 6;
			sprinting = false;
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");

		rb2d.AddForce (Vector2.right * Speed * h);

		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) {
		
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		
		}
	}
}
