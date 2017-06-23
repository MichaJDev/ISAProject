using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour
{

    //weapon damage.......
    public float weaponDamage = 5f;

    //refference to ProjectController to control velocity
    ProjectileController projContr;
    EnemyHealth eh; 

    //Explosion Particle effect
    public GameObject expl;



    // Use this for initialization
    void Awake()
    {
        projContr = GetComponentInParent<ProjectileController>();
        eh = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // When the bullet collides with something it will destroy the bullet and renders the exlosion material
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.gameObject.layer == LayerMask.NameToLayer("Shootable") || c2d.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {

            projContr.removeForce();
            Instantiate(expl, transform.position, transform.rotation);
            Destroy(gameObject);
            //Checking if tag
            if (c2d.gameObject.layer == LayerMask.NameToLayer("Shootable") && c2d.CompareTag("Enemy"))
            {
                eh = c2d.gameObject.GetComponent<EnemyHealth>();
                eh.addDamage(weaponDamage);
            }
        }
    }
    // When the bullet collides with something and it stays in the collider due to something else it will still destroy the bullet and renders the exlosion material
    void OnTriggerStay2D(Collider2D c2d)
    {
        if (c2d.gameObject.layer == LayerMask.NameToLayer("Shootable") || c2d.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {

            projContr.removeForce();
            Instantiate(expl, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
}
