using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	public Material[] materials;
	int decayvalue;
	int id;
	int level;

	void Awake ()
	{
		decayvalue = 0;
	}
	// Use this for initialization
	void Start () {

	}

	public int getLevel()
	{
		return this.level;
	}

	public void setLevel(int level)
	{
		this.level = level;
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
