using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	float timer;
	int actualcount;
	CubeController cc;

	// Use this for initialization
	void Start () {
		timer = 0;
		actualcount = 600;
	
	}

	string countToTime(int actualcount)
	{
		string time = null;
		if(actualcount % 60 == 0)
		{
			time = actualcount % 60+":00";
		}
		else
		{
			if(actualcount%60 >= 10)
			{
				time = Mathf.FloorToInt(actualcount/60) + ":" + actualcount%60;
			}
			else
			{
				string doubledig = "0"+actualcount%60;
				time = Mathf.FloorToInt(actualcount/60) + ":" + doubledig;
			}
		}
		return time;
	}

	void OnGUI()
	{
		GUIStyle mystyle = new GUIStyle ();
		mystyle.alignment = TextAnchor.UpperLeft;
		mystyle.fontSize = 45;
		mystyle.normal.textColor = Color.white;
		string time = countToTime (actualcount);
		GUI.Label (new Rect (Screen.width / 1.5f, Screen.height / 40, Screen.width / 10, Screen.height / 10), time, mystyle);
		if(GUI.Button (new Rect (Screen.width / 10, Screen.height / 1.7f, Screen.width / 8, Screen.height / 15), "Zoom in"))
		{
			//if(Camera.main.fieldOfView >= 40)
			//{
				Camera.main.fieldOfView -= 5;
				mystyle.fontSize = 10;
			//}
		}
		if(GUI.Button (new Rect (Screen.width / 10, Screen.height / 1.45f, Screen.width / 8, Screen.height / 15), "Zoom out"))
		{
			if(Camera.main.fieldOfView < 65){
				Camera.main.fieldOfView += 5;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 1.8f, Screen.width/5, Screen.height / 20), "Up"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.y < 1f)
			{
			myPos.y += .1f;
			Camera.main.transform.position = myPos;
			}
		}

		if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 1.45f, Screen.width/5, Screen.height / 20), "Down"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.y > -1f)
			{
			myPos.y -= .1f;
			Camera.main.transform.position = myPos;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 3.75f, Screen.height / 1.6f, Screen.width/5, Screen.height / 20), "Left"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.x > -1f)
			{
			myPos.x -= .1f;
			Camera.main.transform.position = myPos;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 1.4f, Screen.height / 1.6f, Screen.width/5, Screen.height / 20), "Right"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.x < 1f)
			{
			myPos.x += .1f;
			Camera.main.transform.position = myPos;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if(actualcount > 0)
		{
			timer += Time.deltaTime;
			if(timer >= 1f)
			{
				timer = 0;
				actualcount -= 1;
			}
		}
	
	}
}
