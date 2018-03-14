using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDisplay : MonoBehaviour 
{
	//http://www.theappguruz.com/blog/display-projectile-trajectory-path-in-unity
	public GameObject TrajectoryPrefab;
	private int numOfTrajectoryPoints = 30;
	private List<GameObject> trajectoryPoints;
	private float power = 25;
	void Start()
	{
		trajectoryPoints = new List<GameObject>();
		for(int i = 0; i< numOfTrajectoryPoints; i++)
		{
			GameObject dot = (GameObject)Instantiate(TrajectoryPrefab);
			dot.SetActive(false); //GetComponent<Renderer>().enabled = false;
			trajectoryPoints.Insert(i, dot);
		}
	}
	void OnMouseUp()
	{
		
	}
	void OnMouseDrag()
	{
		Vector2 vel = GetForceFrom(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition));
		float angle = Mathf.Atan2(vel.y,vel.x)* Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0,0,angle);
		setTrajectoryPoints(transform.position, vel/GetComponent<Rigidbody2D>().mass);
	}
	private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y))*power;
    }
	public void setTrajectoryPoints(Vector2 startPos, Vector2 velocity)
	{
		float vel = Mathf.Sqrt((velocity.x * velocity.x) + (velocity.y * velocity.y));
		float angle = Mathf.Rad2Deg * (Mathf.Atan2(velocity.y, velocity.x));
		float fTime = 0;		

		fTime = 0;
		for(int i = 0; i < numOfTrajectoryPoints; i++)
		{
			float dx = vel * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
			float dy = vel * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
			Vector2 pos = new Vector2(startPos.x + dx, startPos.y + dy );
			trajectoryPoints[i].transform.position = pos;
			//trajectoryPoints[i].renderer.enabled = true;
			trajectoryPoints[i].SetActive(true); //GetComponent<Renderer>().enabled = true;
			trajectoryPoints[i].transform.eulerAngles = new Vector3(0,0, Mathf.Atan2(velocity.y -(Physics.gravity.magnitude) * fTime, velocity.x) * Mathf.Rad2Deg);
		}
	}
}
