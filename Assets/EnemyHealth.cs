using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth;

    float currentHealth;


	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentHealth <= 0) {
            Destroy(this.gameObject);
        }
	}

    public void addDamage(float dmg) {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D c2d) {
        if(c2d.CompareTag("Bullet")) {
            Destroy(this.gameObject);
        }
    }
}
