using UnityEngine;
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
	
	void OnMouseEnter()
	{
		hover = true;
	}
	
	void OnMouseOver(){
		
	
		
		if(Input.GetMouseButton(0)){
			timer += Time.deltaTime;

			if(timer>= .1f){

				PoolingSystemExtensions.DestroyAPS(this.gameObject);
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
				timer = 0;
			}
		}
	}
	

	void OnMouseExit(){
		hover = false;
	}
}

