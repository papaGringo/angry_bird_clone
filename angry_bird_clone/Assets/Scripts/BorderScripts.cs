﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScripts : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D co)
	{
		// Debug.Log(co.gameObject.name);
		Destroy(co.gameObject);
	}
}
