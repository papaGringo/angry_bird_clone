using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpawnOnce : MonoBehaviour 
{
	public GameObject effect;	
	void OnCollisionEnter2D(Collision2D other)
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(GetComponent<Trails>());
		Destroy(this);
	}
}
