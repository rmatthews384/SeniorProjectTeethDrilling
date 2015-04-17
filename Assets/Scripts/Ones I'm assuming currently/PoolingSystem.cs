//========================================================================================================================
// Advanced Pooling System - Copyright © 2014 Sumit Das (SwiftFinger Games)
//
// Please direct any bugs/comments/suggestions to swiftfingergames@gmail.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to use
// or modify "Advanced Pooling System" in any and all games, subject to the
// following conditions:
//
// 1. The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// 2. Any product developed using "Advanced Pooling System" requires clearly
// readable "Advanced Pooling System" logo on splash screen or credits screen.
//
// 3. It is expressly forbid to sell or commercially distribute
// "Advanced Pooling System" outside of your games. You can freely use it in
// your games but you cannot commercially distribute the source code either
// directly or compiled into a library outside of your game.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//========================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[AddComponentMenu("AdvancedPoolingSystem/PoolingSystem")]

/// <summary>
/// <para>Version: 1.0.1</para>	 
/// <para>Author: Sumit Das (http://swiftfingergames.blogspot.com)</para>
/// <para>Support: swiftfingergames@gmail.com </para>
/// </summary>

public class Vox
{
	Vector3 position;
	Vector3 listPos;
	GameObject vox;
	int level;
	int decay;
	
	public Vox(Vector3 position, Vector3 listPos, int level, GameObject vox)
	{
		this.position = position;
		this.listPos = listPos;
		this.level = level;
		this.vox = vox;
	}
	
	public void setLevel(int level)
	{
		this.level = level;
	}
	
	public void setDecay(int decay)
	{
		this.decay = decay;
	}

	public Vector3 getPosition()
	{
		return this.position;
	}

	public Vector3 getListPos()
	{
		return this.listPos;
	}

	public int getLevel()
	{
		return this.level;
	}
	
	public int getDecay()
	{
		return this.decay;
	}

	
	public GameObject getVox()
	{
		return this.vox;
	}
}



public sealed class PoolingSystem : MonoBehaviour {
	
	int id = 0;
	CubeController cc;
	public List<Vox> heavyDecay = new List<Vox>();
	public List<List<List<Vox>>> posGrid = new List<List<List<Vox>>>();
	static List<List<Vox>> midList = new List<List<Vox>>();
	static List<Vox> innerList = new List<Vox>();
	static List<GameObject> destroyed = new List<GameObject>();
	static float cubeDim = 0.019f;
	static public int totWork = 0;
	
	[System.Serializable]
	public class PoolingItems
	{
		public GameObject prefab;
		public int amount;
	}

	public static PoolingSystem Instance;
	
	/// <summary>
	/// These fields will hold all the different types of assets you wish to pool.
	/// </summary>
	public PoolingItems[] poolingItems;
	public List<GameObject>[] pooledItems;
	
	/// <summary>
	/// The default pooling amount for each object type, in case the pooling amount is not mentioned or is 0.
	/// </summary>
	public int defaultPoolAmount = 10;
	
	/// <summary>
	/// Do you want the pool to expand in case more instances of pooled objects are required.
	/// </summary>
	public bool poolExpand = true;
	
	void Awake ()
	{
		Instance = this;
	}
	
	void Start () 
	{
		int id = 0;
		CubeController cc;
		heavyDecay = new List<Vox>();
		posGrid = new List<List<List<Vox>>>();
		midList = new List<List<Vox>>();
		innerList = new List<Vox>();
		destroyed = new List<GameObject>();
		cubeDim = 0.019f;
		Vector3 startvector;
		float valueat28 = 0;
		startvector = new Vector3 (.95f, .95f, 0);
		pooledItems = new List<GameObject>[poolingItems.Length];
		Vox myVox;
		for (int i=0; i<poolingItems.Length; i++) {
			pooledItems [i] = new List<GameObject> ();
			GameObject newItem;
			int poolingAmount;
			if (poolingItems [i].amount > 0)
				poolingAmount = poolingItems [i].amount;
			else
				poolingAmount = defaultPoolAmount;

			for (int j=0; j<35; j++) {
				startvector.x = .95f;

				if (j == 34 || j == 0) {				// this checks for the first and last rows
					startvector.x -= cubeDim * 6;		// offset by 6 cubes
					for (int c = 0; c < 6; c++) {
						innerList.Add (null);
					}
					for (int k = 6; k < 29; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
					}
					for (int c = 0; c < 6; c++) {
						innerList.Add (null);
					}
				} else if (j == 33 || j == 1) {
					startvector.x -= cubeDim * 5;
					for (int c = 0; c < 5; c++) {
						innerList.Add (null);
					}
					for (int k = 5; k < 30; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
					}
					for (int c = 0; c < 5; c++) {
						innerList.Add (null);
					}
				} else if (j == 32 || j == 2) {
					startvector.x -= cubeDim * 4;
					for (int c = 0; c < 4; c++) {
						innerList.Add (null);
					}
					for (int k = 4; k < 31; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
					}
					for (int c = 0; c < 4; c++) {
						innerList.Add (null);
					}
				} else if (j == 31 || j == 3) {
					startvector.x -= cubeDim * 3;
					for (int c = 0; c < 3; c++) {	
						innerList.Add (null);
					}
					for (int k = 3; k < 32; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
					}
					for (int c = 0; c < 3; c++) {
						innerList.Add (null);
					}
				} else if (j == 30 || j == 4) {
					startvector.x -= cubeDim * 2;
					for (int c = 0; c < 2; c++) {
						innerList.Add (null);
					}
					for (int k = 2; k < 33; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
					}
					for (int c = 0; c < 2; c++) {
						innerList.Add (null);
					}
				} else if (j == 29 || j == 5) {
					startvector.x -= cubeDim;
					innerList.Add (null);
					for (int k = 1; k < 34; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
					}
					innerList.Add (null);
				} else {
					for (int k = 0; k < 35; k++) {
						startvector.x -= cubeDim;
						newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3 (0, j, k);
						myVox = new Vox (startvector, listPos, 0, newItem);
						innerList.Add (myVox);
						cc = newItem.GetComponent<CubeController> ();
						cc.setID (id);
						id++;
						newItem.SetActive (true);
						pooledItems [i].Add (newItem);
						newItem.transform.parent = transform;
						if (j == 28) {
							valueat28 = startvector.y;
						}
					}
				}
				midList.Add (innerList);
				innerList = new List<Vox> ();
				startvector.y -= cubeDim;
			}
			posGrid.Add (midList);
			midList = new List<List<Vox>>();


			startvector = new Vector3(.95f, .95f, 0);
			//Front Depth
			for (int h = 1; h < 25; h++) {
				startvector.z += cubeDim;
				startvector.y = .95f;

				for(int u = 0; u < 35; u ++){
					startvector.x = .95f;

					for(int q = 0; q < 35; q++){
				
						innerList.Add(null);

						if(u == 34 && (q >5 && q < 29)){
							if(q ==6){
								startvector.x -= 7*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}

						else if( u == 33 && (q == 5 || q == 29)){
							if(q ==5){
								startvector.x -= 6*cubeDim;
							}
							if(q == 29){
								startvector.x -= 23*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}

						else if( u == 32 && (q == 4 || q == 30)){
							if(q ==4){
								startvector.x -= 5*cubeDim;
							}
							if(q == 30){
								startvector.x -= 25*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}

						else if( u == 31 && (q == 3 || q == 31)){
							if(q ==3){
								startvector.x -= 4*cubeDim;
							}
							if(q == 31){
								startvector.x -= 27*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}

						else if( u == 30 && (q == 2 || q == 32)){
							if(q ==2){
								startvector.x -= 3*cubeDim;
							}
							if(q == 32){
								startvector.x -= 29*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}

						else if( u == 29 && (q == 1 || q == 33)){
							if(q ==1){
								startvector.x -= 2*cubeDim;
							}
							if(q == 33){
								startvector.x -= 31*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}

						else if( u == 28 && (q == 0 || q == 34)){
							if(q ==0){
								startvector.x -= cubeDim;
							}
							if(q == 34){
								startvector.x -= 33*cubeDim;
							}
							newItem = (GameObject)Instantiate (poolingItems [i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3 (h, u, q);
							myVox = new Vox (startvector, listPos, 0, newItem);
							innerList.RemoveAt(q);
							innerList.Insert (q, myVox);
							cc = newItem.GetComponent<CubeController> ();
							cc.setID (id);
							id++;
							newItem.SetActive (true);
							pooledItems [i].Add (newItem);
							newItem.transform.parent = transform;
							startvector.x -= cubeDim;
						}
					}
					midList.Add (innerList);
					innerList = new List<Vox> ();
					startvector.y -= cubeDim;
				}
				//print(midList.Count);
				posGrid.Add(midList);
				midList = new List<List<Vox>>();
			}
		}

		//Decay

		int x = Random.Range(15,26);
		int y = Random.Range(15,26);
		myVox = posGrid[0][x][y];
		myVox.setDecay(4);
		posGrid[0][x][y].setDecay(4);
		GameObject vox = myVox.getVox();
		cc = vox.GetComponent<CubeController>();
		cc.setMaterial(4);
		heavyDecay.Add(myVox);
		int newX = x;
		int newY = y;
		for(int i = 0; i < Random.Range(1,9); i++)
		{
			newX -= 1;
			myVox = posGrid[0][newX][y];
			myVox.setDecay(4);
			posGrid[0][newX][y].setDecay(4);
			vox = myVox.getVox();
			cc =  vox.GetComponent<CubeController>();
			cc.setMaterial(4);
			heavyDecay.Add(myVox);
			newY = y;
			for(int j = 0; j < 4; j++)
			{
				newY += 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
			newY = y;
			for(int j = 0; j < 4; j++)
			{
				newY -= 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
		}
		newX = x;
		newY = y;
		for(int i = 0; i < Random.Range(1,9); i++)
		{
			newX += 1;
			myVox = posGrid[0][newX][y];
			myVox.setDecay(4);
			posGrid[0][newX][y].setDecay(4);
			vox = myVox.getVox();
			cc = vox.GetComponent<CubeController>();
			cc.setMaterial(4);
			heavyDecay.Add(myVox);
			newY = y;
			for(int j = 0; j < 4; j++)
			{
				newY += 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
			newY = y;
			for(int j = 0; j < 4; j++)
			{
				newY -= 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
		}
		newX = x;
		newY = y;
		for(int i = 0; i < Random.Range(1,9); i++)
		{
			newY -= 1;
			myVox = posGrid[0][x][newY];
			myVox.setDecay(4);
			posGrid[0][x][newY].setDecay(4);
			vox = myVox.getVox();
			cc = vox.GetComponent<CubeController>();
			cc.setMaterial(4);
			heavyDecay.Add(myVox);
			newX = x;
			for(int j = 0; j < 4; j++)
			{
				newX += 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
			newX = x;
			for(int j = 0; j < 4; j++)
			{
				newX -= 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
		}
		newX = x;
		newY = y;
		for(int i = 0; i < Random.Range(1,9); i++)
		{
			newY += 1;
			myVox = posGrid[0][x][newY];
			myVox.setDecay(4);
			posGrid[0][x][newY].setDecay(4);
			vox = myVox.getVox();
			cc = vox.GetComponent<CubeController>();
			cc.setMaterial(4);
			heavyDecay.Add(myVox);
			newX = x;
			for(int j = 0; j < 4; j++)
			{
				newX += 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
			newX = x;
			for(int j = 0; j < 4; j++)
			{
				newX -= 1;
				myVox = posGrid[0][newX][newY];
				myVox.setDecay(4);
				posGrid[0][newX][newY].setDecay(4);
				vox = myVox.getVox();
				cc = vox.GetComponent<CubeController>();
				cc.setMaterial(4);
				heavyDecay.Add(myVox);
			}
		}
		Instantiate (Resources.Load ("decay"));

		//extra top height
		/*for(int j = 0; j < 5; j++)
		{
		startvector.x = .95f-cubeDim*3;
		startvector.y = .95f;
		startvector.z = -cubeDim;
		GameObject newItem2;
		GameObject singleFiller = (GameObject)Resources.Load ("singleFillerCube");
		GameObject quadFiller = (GameObject)Resources.Load ("quadCube");
		startvector.y -= cubeDim * 6;
		for(int i = 0; i < 22; i++)
		{
				newItem2 = (GameObject)Instantiate (quadFiller, startvector, Quaternion.identity);
				newItem2.SetActive (true);
				startvector.y -= cubeDim;
		}
		}

		for(int j = 0; j < 5; j++)
		{
			startvector.x = .95f-cubeDim*33;
			startvector.y = .95f;
			startvector.z = -cubeDim;
			GameObject newItem2;
			GameObject singleFiller = (GameObject)Resources.Load ("singleFillerCube");
			GameObject quadFiller = (GameObject)Resources.Load ("quadCube");
			startvector.y -= cubeDim * 6;
			for(int i = 0; i < 22; i++)
			{
				newItem2 = (GameObject)Instantiate (quadFiller, startvector, Quaternion.identity);
				newItem2.SetActive (true);
				startvector.y -= cubeDim;
			}
		}*/
		


	}

	public void calcTotDecay(){
		List<List<Vox>> l2;
		List<Vox> l1;

		l2 = posGrid[0];
		for(int k = 0; k < l2.Count; k++){
			l1 = l2[k];
			for(int m = 0; m < l1.Count; m++){
				Vox v = l1[m];
				if(v != null){
					if(v.getVox().GetComponent<CubeController>().getDecay() == 4 || v.getDecay() == 4){
						totWork += 10;
					}
					else if(v.getVox().GetComponent<CubeController>().getDecay() == 3 || v.getDecay() == 3){
						totWork += 8;
					}
					else if(v.getVox().GetComponent<CubeController>().getDecay() == 2 || v.getDecay() == 2){
						totWork += 5;
					}
					else if(v.getVox().GetComponent<CubeController>().getDecay() == 1 || v.getDecay() == 1){
						totWork += 2;
					}
				}
			}
		}
	
	}

	public static void DestroyAPS(GameObject myObject)
	{
		destroyed.Add (myObject);
		myObject.SetActive(false);
	}

	public static int Score(){
		double total = 0;
		double decayDestroy = 0;
		double enamelDestroy =0;

		for(int q = 0; q < destroyed.Count; q++){
			//print(destroyed[q].GetType());
			if(destroyed[q].GetComponent<CubeController>().getDecay() > 0){
				decayDestroy++;
			}
			else{
				enamelDestroy++;
			}
		}
		total = (int)(((100*decayDestroy/totWork) - (enamelDestroy/50d)));
		Debug.Log("decayDestroy/totWork " + decayDestroy/totWork*100 +" enamelDestroy/25 " + enamelDestroy/50 + " scale to .05 " + (enamelDestroy/25)*.05 + " "  + total);
		return (int)total;
		//Application.LoadLevel("score");

	}

	public GameObject InstantiateAPS (string itemType)
	{
		GameObject newObject = GetPooledItem(itemType);
		newObject.SetActive(true);
		return newObject;
	}
	
	
	
	public GameObject InstantiateAPS (string itemType, Vector3 itemPosition, Quaternion itemRotation)
	{
		
		GameObject newObject = GetPooledItem(itemType);
		Vector3 zeroposition = itemPosition;
		Vector3 oldPosition = itemPosition;
		oldPosition.z -= cubeDim;
		zeroposition.z = 0;
		int decay = 1;
		if(itemPosition.x > .931f || itemPosition.x < .285 || itemPosition.y > .95f || itemPosition.y < .304f)
		{
			return newObject;
		}


		/*for(int i =0; i < destroyed.Count; i++)
		{
			if(destroyed[i].transform.position == itemPosition)
			{
				return newObject;
			}
		}*/
		int count = posGrid.Count;

		cc = newObject.GetComponent<CubeController> ();
		newObject.transform.position = itemPosition;
		newObject.transform.rotation = itemRotation;

		int vectory = 0;
		int vectorx = 0;

			vectorx = Mathf.RoundToInt(itemPosition.x/cubeDim);
			vectorx = (vectorx-49)*-1;


			vectory = Mathf.RoundToInt(itemPosition.y/cubeDim);
			vectory = (vectory - 50) * -1;
	

		if(posGrid[Mathf.RoundToInt(itemPosition.z/cubeDim)][vectory][vectorx] != null )
		{
				return newObject;
	
		}

		if(posGrid[Mathf.RoundToInt(itemPosition.z/cubeDim)][vectory][vectorx] == null &&posGrid[0][vectory][vectorx] != null)
		{
				decay = posGrid[0][vectory][vectorx].getDecay();

		}
		else
		{
			return newObject;
		}
	
		Vector3 listPos = new Vector3 (Mathf.RoundToInt(itemPosition.z / cubeDim), vectory, vectorx);
		Vox myVox = new Vox(itemPosition, listPos, (int)(itemPosition.z/cubeDim), newObject);

			int multiple = Mathf.RoundToInt(itemPosition.z/cubeDim);
			if(decay == 4)
			{
				if(multiple <= 1)
				{
				cc.setMaterial(4);
				myVox.setDecay (4);
				}
				else if(multiple > 1 && multiple <= 4)
				{
					cc.setMaterial(3);
					myVox.setDecay (3);
				}
				else if(multiple > 4 && multiple <= 7)
				{
					cc.setMaterial(2);
					myVox.setDecay (2);
				}
				else if(multiple > 7 && multiple <= 9)
				{
					cc.setMaterial(1);
					myVox.setDecay (1);
				}
				else if(multiple >= 10)
				{
					cc.setMaterial(0);
					myVox.setDecay (0);
				}
			}
			else if(decay == 3)
			{
				if(multiple <= 1)
				{
					cc.setMaterial(3);
					myVox.setDecay (3);
				}
				else if(multiple > 1 && multiple <= 4)
				{
					cc.setMaterial(2);
					myVox.setDecay (2);
				}
				else if(multiple > 4 && multiple <= 7)
				{
					cc.setMaterial(1);
					myVox.setDecay (1);
				}
				else
				{
					cc.setMaterial(0);
					myVox.setDecay (0);
				}
			}
			else if(decay == 2)
			{
				if(multiple <= 1)
				{
					cc.setMaterial(2);
					myVox.setDecay (2);
				}
				else if(multiple > 1 && multiple <= 4)
				{
					cc.setMaterial(1);
					myVox.setDecay (1);
				}
				else 
				{
					cc.setMaterial(0);
					myVox.setDecay (0);
				}
			}
			else if(decay == 1)
			{
				if(multiple <= 1)
				{
					cc.setMaterial(1);
					myVox.setDecay (1);
				}
				else 
				{
					cc.setMaterial(0);
					myVox.setDecay (0);
				}
			}
			else
			{
				cc.setMaterial(0);
				myVox.setDecay (0);
			}
		

			innerList = new List<Vox>();
			midList = new List<List<Vox>>();
			innerList = posGrid [(int)myVox.getListPos ().x] [(int)myVox.getListPos ().y] ;
			innerList[(int)myVox.getListPos ().z] = myVox;
			midList = posGrid [(int)myVox.getListPos ().x];
			midList[(int)myVox.getListPos ().y] = innerList;
			posGrid [(int)myVox.getListPos ().x] = midList;
		        

		cc.setLevel (Mathf.RoundToInt(itemPosition.z / .019f));
		newObject.SetActive (true);
			
		return newObject;
		
	}
	
	public GameObject InstantiateAPS (string itemType, Vector3 itemPosition, Quaternion itemRotation, GameObject myParent)
	{
		if(GetPooledItem(itemType) != null){
			GameObject newObject = GetPooledItem(itemType);
			newObject.transform.position = itemPosition;
			newObject.transform.rotation = itemRotation;
			newObject.transform.parent = myParent.transform;
			newObject.SetActive(true);
			return newObject;
		}
		return null;
	}
	
	public static void PlayEffect(GameObject particleEffect, int particlesAmount)
	{
		if(particleEffect.particleSystem)
		{
			particleEffect.particleSystem.Emit(particlesAmount);
		}
	}
	
	public static void PlaySound(GameObject soundSource)
	{
		if(soundSource.audio)
		{
			soundSource.audio.PlayOneShot(soundSource.audio.GetComponent<AudioSource>().clip);
		}
	}
	
	public GameObject GetPooledItem (string itemType)
	{
		for(int i=0; i<poolingItems.Length; i++)
		{
			if(poolingItems[i].prefab.name == itemType)
			{
				for(int j=0; j<pooledItems[i].Count; j++)
				{
					if(!pooledItems[i][j].activeInHierarchy)
					{
						return pooledItems[i][j];
					}
				}
				
				if(poolExpand)
				{
					GameObject newItem = (GameObject) Instantiate(poolingItems[i].prefab);
					newItem.SetActive(false);
					cc = newItem.GetComponent<CubeController>();
					cc.setID(id);
					pooledItems[i].Add(newItem);
					newItem.transform.parent = transform;
					id++;
					return newItem;
				}
				
				break;
			}
		}
		
		return null;
	}
	
}

public static class PoolingSystemExtensions
{
	public static void DestroyAPS(this GameObject myobject)
	{
		PoolingSystem.DestroyAPS(myobject);
	}
	
	public static void PlayEffect(this GameObject particleEffect, int particlesAmount)
	{
		PoolingSystem.PlayEffect(particleEffect, particlesAmount);
	}
	
	public static void PlaySound(this GameObject soundSource)
	{
		PoolingSystem.PlaySound(soundSource);
	}
}
