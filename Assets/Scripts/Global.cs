using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	bool mousedown;

	public void setMouseDown(bool mouse)
	{
		mousedown = mouse;
	}

	public bool getMouseDown()
	{
		return this.mousedown;
	}

	// Use this for initialization
	void Start () {
		mousedown = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
