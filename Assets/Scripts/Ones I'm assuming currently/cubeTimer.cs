﻿using UnityEngine;
using System.Collections;

public class cubeTimer : MonoBehaviour {

	float timer;
	bool hover;
	PoolingSystem pS;
	CubeController cc;
	Global global;
	static float cubeDim = 0.019f;

	// Use this for initialization
	void Start () 
	{
		Input.simulateMouseWithTouches = true;
		global = (GameObject.FindGameObjectWithTag ("MainCamera")).GetComponent<Global>();
		cc = gameObject.GetComponent<CubeController>();
		pS = PoolingSystem.Instance;
		timer = 0;
		hover = false;
	}

	void OnMouseDown()
	{
		global.setMouseDown (true);

	}

	void OnMouseEnter()
	{
		hover = true;
	}

	void OnMouseExit()
	{
		hover = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonUp (0))
		{
			global.setMouseDown(false);
		}

		if(global.getMouseDown() && hover)
		{
			timer += Time.deltaTime;
		}
		if(timer >= .1f)
		{
			timer = 0;
			Vector3 myposition = this.gameObject.transform.position;
			Vector3 myoldposition;
			myposition.z += cubeDim;
			pS.InstantiateAPS("cube", myposition, Quaternion.identity);
			myoldposition = myposition;
			myposition.x += cubeDim;
			pS.InstantiateAPS("cube", myposition, Quaternion.identity);
			myposition = myoldposition;
			myposition.x -= cubeDim;
			pS.InstantiateAPS("cube", myposition, Quaternion.identity);
			myposition = myoldposition;
			myposition.y += cubeDim;
			pS.InstantiateAPS("cube", myposition, Quaternion.identity);
			myposition = myoldposition;
			myposition.y -= cubeDim;
			pS.InstantiateAPS("cube", myposition, Quaternion.identity);
			
			PoolingSystemExtensions.DestroyAPS(this.gameObject);

		}
	}
}
