using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour 
{
	public GameObject birdPrefab;
	bool occupied = false;
	void FixedUpdate()
	{
		if(!occupied && !sceneMoving())
		{
			spawnNext();
		}
	}
	void spawnNext()
	{
		Instantiate(birdPrefab, transform.position, Quaternion.identity);
		occupied = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		occupied = false;	
	}
	bool sceneMoving()
	{
		Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
		foreach(Rigidbody2D rb in bodies)
		{
			if(rb.velocity.sqrMagnitude > 5)
			{
				return true;
			}
		}
		return false;
	}
}
