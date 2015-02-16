using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour {

	GameObject[] voxArray = new GameObject[1000];
	Vector3 startvector;
	cubeTimer ct;
	// Use this for initialization
	void Start () {
		startvector = new Vector3 (.85f, .85f, 0);
		for(int i = 0; i < 100; i++)
		{
			voxArray[i] = (GameObject)Resources.Load("cube");
		}
		int x = 0;
			for(int j = 0; j < 10; j++)
			{
				
				startvector.x = .85f;
				for(int k = 0; k < 10; k++)
				{
					startvector.x -= .17f;
					voxArray[x] = (GameObject)Instantiate (voxArray[x], startvector, Quaternion.identity);
				}
				startvector.y -= .17f;
			}
			startvector.x = .85f;
			startvector.y = .85f;
			startvector.z -= .17f;

	}


	// Update is called once per frame
	void Update () {

	}
	

}
