using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	public Material[] materials;
	int decayvalue;

	void Awake ()
	{
		decayvalue = 0;
	}
	// Use this for initialization
	void Start () {

	}

	public int getDecay()
	{
		return this.decayvalue;
	}

	public void setMaterial(int material)
	{
		gameObject.renderer.material = materials [material];
		Debug.Log ("setMaterial");
		decayvalue = material;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
