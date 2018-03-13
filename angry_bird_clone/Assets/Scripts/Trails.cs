using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour 
{
	public GameObject[] trails;
	int next = 0;
	void Start()
	{
		InvokeRepeating("spawnTrail", 0.1f, 0.1f);
	}
	void spawnTrail()
	{
		Instantiate(trails[next], transform.position, Quaternion.identity);
		next = (next + 1) % trails.Length;
	}
}
