using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour 
{
	public Transform rubberLeft;
	public Transform rubberRight;
	/*
		Note: at first we calculate the direction from the bird to the rubber. 
		Then we calculate the angle of this direction. 
		Afterwards we set the rubber's rotation to that angle by using Quaternion.AngleAxis. 
		Finally we use basic vector math to calculate the distance between the rubber and the bird. 
		Afterwards we set the horizontal scale to that distance (plus half the width of the bird, which is bounds.extents.x).
	 */
	void adjustRubber(Transform bird, Transform rubber)
	{
		Vector2 dir = rubber.position - bird.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		rubber.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		float dist = Vector3.Distance(bird.position, rubber.position);
		dist += bird.GetComponent<Collider2D>().bounds.extents.x;
		rubber.localScale = new Vector2(dist, 1);
	}	
	void OnTriggerStay2D(Collider2D coll)
	{
		adjustRubber(coll.transform, rubberLeft);
		adjustRubber(coll.transform, rubberRight);	
	}	
	void OnTriggerExit2D(Collider2D coll)
	{
		rubberLeft.localScale = new Vector2(0,1);
		rubberRight.localScale = new Vector2(0,1);
	}	
}
