using UnityEngine;
using System.Collections;

/*
 *  This is an universal destroy script which will basically make it easier for particles to be alive and
 *  as well for entities that can sit on the ground like drops.
 */

public class destroyController : MonoBehaviour {
    public float aliveTime;
	// Use this for initialization
	void Awake () {
        //destroy the object 
        Destroy(gameObject, aliveTime );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
