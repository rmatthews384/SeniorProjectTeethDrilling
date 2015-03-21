using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	public Material[] materials;
	int decayvalue;
	int id;
	int count;

	void Awake ()
	{
		decayvalue = 0;
	}
	// Use this for initialization
	void Start () {

	}

	public int getCount()
	{
		return this.count;
	}

	public void setCount(int count)
	{
		this.count = count;
	}

	public int getDecay()
	{
		return this.decayvalue;
	}

	public void setID(int ID)
	{
		this.id = ID;
	}

	public int getID()
	{
		return id;
	}

	public void setMaterial(int material)
	{
		gameObject.renderer.material = materials [material];
		decayvalue = material;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
