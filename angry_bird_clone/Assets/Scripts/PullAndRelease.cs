using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour 
{
	public float force = 800;
	Vector2 startPos;
	Rigidbody2D rb;
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		startPos = transform.position;
	}
	void OnMouseUp()
	{
		//fire bird
		rb.bodyType = RigidbodyType2D.Dynamic;

		Vector2 dir = startPos - (Vector2)transform.position;
		Debug.Log(dir);
		rb.AddForce(dir * force);

		//remove script (not game object)
		Destroy(this);
	}	
	void OnMouseDrag()
	{
		//move bird
		Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float radius = 2f;
		Vector2 dir = p - startPos;
		if(dir.sqrMagnitude > radius)
		{
			dir = dir.normalized * radius;
		}
		transform.position = startPos + dir;
	}
}
