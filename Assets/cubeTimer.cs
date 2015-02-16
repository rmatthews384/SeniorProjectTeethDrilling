﻿using UnityEngine;
using System.Collections;

public class cubeTimer : MonoBehaviour {

	int id;
	float timer;
	bool hit;
	bool nodown;
	bool destroy;
	Vector3 position;
	Vector3 oldposition = new Vector3(-100,-100,-100);
	PoolingSystem pS;

	// Use this for initialization
	void Start () 
	{
		pS = PoolingSystem.Instance;
		timer = 0;
		hit = false;
	}

	public void setId(int id)
	{
		this.id = id;
	}

	void OnMouseUpAsButton()
	{
		Debug.Log ("OFF");

	}

	void OnMouseDown()
	{
		hit = true;

	}

	// Update is called once per frame
	void Update () 
	{
		Debug.Log (timer);
		if(hit)
		{
			position = Input.mousePosition;
			if(position == oldposition || oldposition == new Vector3(-100,-100,-100))
			{
			timer += Time.deltaTime;
			}
			else
			{
				hit = false;
			}
			oldposition = position;
		}
		if(timer >= 1)
		{
			timer = 0;
			Vector3 myposition = this.gameObject.transform.position;
			myposition.z += .19f;
			PoolingSystemExtensions.DestroyAPS(this.gameObject);
			pS.InstantiateAPS("cube", myposition, Quaternion.identity);
		}
	}
}
