using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAutoDestroy : MonoBehaviour 
{
	public float maxLife = 5.0f;
	float timeSpan = 0f;
	void Update () 
	{
		timeSpan += Time.deltaTime;
		if(timeSpan > maxLife)
		{
			Destroy(gameObject);
		}
	}
}
