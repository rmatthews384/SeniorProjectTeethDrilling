using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	float timer;
	int actualcount;
	CubeController cc;
	static float ow;
	static float change;
	static float amtChange;
	static float amtChange2;
	static bool rot =false;
	static bool window = false;
	static int finalScore = 0;
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
	

		if(GUI.Button (new Rect (Screen.width / 11, Screen.height / 1.45f, Screen.width / 5, Screen.height / 15), "Zoom in"))
		{
			//if(Camera.main.fieldOfView >= 40)
			//{
				Camera.main.fieldOfView -= 5;
				mystyle.fontSize = 10;
			//}
		}
		if(GUI.Button (new Rect (Screen.width / 11, Screen.height / 1.2f, Screen.width / 5, Screen.height / 15), "Zoom out"))
		{
			if(Camera.main.fieldOfView < 65){
				Camera.main.fieldOfView += 5;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 2.3f, Screen.height / 1.425f, Screen.width/8, Screen.height / 20), "Up"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.y < 1f)
			{
			myPos.y += .1f;
			Camera.main.transform.position = myPos;
			}
		}

		if(GUI.Button (new Rect (Screen.width / 2.3f, Screen.height / 1.2f, Screen.width/8, Screen.height / 20), "Down"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.y > -1f)
			{
			myPos.y -= .1f;
			Camera.main.transform.position = myPos;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 3, Screen.height / 1.3f, Screen.width/8, Screen.height / 20), "Left"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.x > -1f)
			{
			myPos.x -= .1f;
			Camera.main.transform.position = myPos;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 1.85f, Screen.height / 1.3f, Screen.width/8, Screen.height / 20), "Right"))
		{
			Vector3 myPos = Camera.main.transform.position;
			if(myPos.x < 1f)
			{
			myPos.x += .1f;
			Camera.main.transform.position = myPos;
			}
		}
		if(GUI.Button (new Rect (Screen.width / 1.4f, Screen.height / 1.2f, Screen.width/5, Screen.height / 15), "Score"))
		{
			finalScore = PoolingSystem.Score();
			window = true;

		}
		
		if(GUI.Button (new Rect (Screen.width / 1.4f, Screen.height / 1.45f, Screen.width / 5, Screen.height / 15), "Open Wide"))
		{
			float current = Camera.main.transform.rotation.eulerAngles.x;
			if((int)current == 330){
				//Camera.main.transform.Rotate(Vector3.right , 30);
				rot = true;
				amtChange = 0;
				amtChange2 = 0;
				change = 30;
				ow = 0;
				
			}
		}

		
		if(window){
			//GUIStyle scorstyle = new GUIStyle();
			//scorstyle.fontSize = 20;
			GUI.color = new Color(1,1,1, 30);
			GUI.backgroundColor = Color.black;
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Results");
			GUI.Label(new Rect (Screen.width / 2.1f, Screen.height / 15f, Screen.width/8, Screen.height / 20), finalScore.ToString()+"%");
			if(GUI.Button(new Rect (Screen.width / 2.3f, Screen.height / 8f, Screen.width/8, Screen.height / 20), "Again")){
				Application.LoadLevel("tooth");
				window = false;
			}
		}

	}
	// Update is called once per frame
	void Update () {
		if(actualcount > 0 && !window)
		{
			timer += Time.deltaTime;
			if(timer >= 1f)
			{
				timer = 0;
				actualcount -= 1;
			}
		}
		//float current = Camera.main.transform.rotation.eulerAngles.x;

		if(rot){
			if(amtChange < 30){
				ow = 10*Time.deltaTime;
				Camera.main.transform.Rotate(Vector3.right , ow, Space.Self);
				amtChange += ow;
				Vector3 myPos = Camera.main.transform.position;
				myPos.y += .03f;
				Camera.main.transform.position = myPos;
			}
			else if( amtChange >29 && amtChange < 100){
				ow = 10* Time.deltaTime;
				amtChange += ow;
			}
			else if(amtChange > 99 && amtChange2 < 30){
				ow = 10*Time.deltaTime;
				Camera.main.transform.Rotate(Vector3.right , -ow, Space.Self);
				amtChange2 += ow;
				Vector3 myPos = Camera.main.transform.position;
				myPos.y -= .03f;
				Camera.main.transform.position = myPos;
			}
			else{
				rot = false;
				Quaternion qua=new Quaternion();
				qua.eulerAngles = new Vector3(330, 0, 0);
				transform.rotation=qua;
			}
		}
	}
}
