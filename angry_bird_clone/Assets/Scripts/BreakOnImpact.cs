using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpact : MonoBehaviour 
{
	/*
		Note: Collision2D is the info that gets passed to the OnCollisionEnter2D function. 
		It contains the relativeVelocity, which is pretty much the direction multiplied with the speed. 
		If we only care about the speed then we can calculate the length of that vector by using sqrMagnitude. 
		Now if the object that caused the collision also has a Rigidbody then we will multiply the speed with the Rigidbody's mass. 
		Otherwise we return only the speed.
	 */
	 [Range(600, 1300)]
	 public float forceNeeded = 1000f;
	float collisionForce(Collision2D coll)
	{
		// F = m * a
		float speed = coll.relativeVelocity.sqrMagnitude;
		if(coll.collider.GetComponent<Rigidbody2D>())
		{
			return speed * coll.collider.GetComponent<Rigidbody2D>().mass;
		}
		return speed;
	}	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(collisionForce(coll) >= forceNeeded)
		{
			Destroy(gameObject);
		}
	}
}
