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
	int count;
	
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

	public void setCount(int count)
	{
		this.count = count;
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

	public int getCount()
	{
		return this.count;
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
	static ArrayList destroyed = new ArrayList();
	static float cubeDim = 0.019f;
	
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
		Vector3 startvector;
		startvector = new Vector3 (.95f, .95f, 0);
		pooledItems = new List<GameObject>[poolingItems.Length];
		for(int i=0; i<poolingItems.Length; i++)
		{
			pooledItems[i] = new List<GameObject>();
			GameObject newItem;
			int poolingAmount;
			if(poolingItems[i].amount > 0) poolingAmount = poolingItems[i].amount;
			else poolingAmount = defaultPoolAmount;
			for(int j=0; j<70; j++)
			{
				startvector.x = .95f;
					if(j == 69 || j== 0){
						startvector.x -= cubeDim*6;
						for(int k = 6; k < 64; k++)	{
							startvector.x -= cubeDim;
							newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3(0,j,k);
							Vox myVox = new Vox(startvector, listPos, 0, newItem);
							innerList.Add(myVox);
							cc = newItem.GetComponent<CubeController>();
							cc.setID(id);
							id++;
							newItem.SetActive(true);
							pooledItems[i].Add(newItem);
							newItem.transform.parent = transform;
						}
					}	
					else if (j == 68 || j == 1){
						startvector.x -= cubeDim *5;
						for(int k = 5; k < 65; k++)	{
							startvector.x -= cubeDim;
							newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3(0,j,k);
							Vox myVox = new Vox(startvector, listPos, 0, newItem);
							innerList.Add(myVox);
							cc = newItem.GetComponent<CubeController>();
							cc.setID(id);
							id++;
							newItem.SetActive(true);
							pooledItems[i].Add(newItem);
							newItem.transform.parent = transform;
						}
					}
					else if( j == 67 || j ==2 ){
						startvector.x -= cubeDim*4;
						for(int k = 4; k < 66; k++)	{
							startvector.x -= cubeDim;
							newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3(0,j,k);
							Vox myVox = new Vox(startvector, listPos, 0, newItem);
							innerList.Add(myVox);
							cc = newItem.GetComponent<CubeController>();
							cc.setID(id);
							id++;
							newItem.SetActive(true);
							pooledItems[i].Add(newItem);
							newItem.transform.parent = transform;
						}
					}
					else if( j == 66 || j ==3){
						startvector.x -= cubeDim*3;
							for(int k = 3; k < 67; k++)	{
							startvector.x -= cubeDim;
							newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3(0,j,k);
							Vox myVox = new Vox(startvector, listPos, 0, newItem);
							innerList.Add(myVox);
							cc = newItem.GetComponent<CubeController>();
							cc.setID(id);
							id++;
							newItem.SetActive(true);
							pooledItems[i].Add(newItem);
							newItem.transform.parent = transform;
						}
					}
					else if (j == 65 || j == 4){
						startvector.x -= cubeDim*2;
							for(int k = 2; k < 68; k++)	{
							startvector.x -= cubeDim;
							newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3(0,j,k);
							Vox myVox = new Vox(startvector, listPos, 0, newItem);
							innerList.Add(myVox);
							cc = newItem.GetComponent<CubeController>();
							cc.setID(id);
							id++;
							newItem.SetActive(true);
							pooledItems[i].Add(newItem);
							newItem.transform.parent = transform;
						}
					}
					else if ( j == 64 || j == 5){
						startvector.x -= cubeDim;
							for(int k = 1; k < 69; k++)	{
							startvector.x -= cubeDim;
							newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
							Vector3 listPos = new Vector3(0,j,k);
							Vox myVox = new Vox(startvector, listPos, 0, newItem);
							innerList.Add(myVox);
							cc = newItem.GetComponent<CubeController>();
							cc.setID(id);
							id++;
							newItem.SetActive(true);
							pooledItems[i].Add(newItem);
							newItem.transform.parent = transform;
						}
					}
				else{
					for(int k = 0; k < 70; k++)
					{

						startvector.x -= cubeDim;
						newItem = (GameObject) Instantiate(poolingItems[i].prefab, startvector, Quaternion.identity);
						Vector3 listPos = new Vector3(0,j,k);
						Vox myVox = new Vox(startvector, listPos, 0, newItem);
						innerList.Add(myVox);
						cc = newItem.GetComponent<CubeController>();
						cc.setID(id);
						id++;
						newItem.SetActive(true);
						pooledItems[i].Add(newItem);
						newItem.transform.parent = transform;
					}
				}
				midList.Add(innerList);
				innerList = new List<Vox>();
				startvector.y -= cubeDim;
			}
		}
		posGrid.Add (midList);
		for(int i = 0; i < 30; i++)
		{
			int x = Random.Range(3,67);
			int y = Random.Range(3,67);
			Debug.Log("x: " + x + " y: " + y);
			Vox myVox = posGrid[0][x][y];
			myVox.setDecay(4);
			myVox.setCount(2);
			GameObject vox = myVox.getVox();
			cc = vox.GetComponent<CubeController>();
			cc.setMaterial(4);
			cc.setCount(2);
			heavyDecay.Add(myVox);
		}
		//Instantiate (Resources.Load ("decay"));
	}

	
	
	public static void DestroyAPS(GameObject myObject)
	{
		destroyed.Add (myObject.transform.position);
		myObject.SetActive(false);
		Score();
	}

	public static void Score(){
		int total = 0;
		int decayDestroy = 0;
		int enamelDestroy =0;

		for(int q = 0; q < destroyed.Count; q++){
			print(destroyed[q].GetType());
			if(0> 0){
				decayDestroy++;
			}
			else{
				enamelDestroy++;
			}
		}
		//print(decayDestroy);
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
		bool found = false;
		int decay = 1;
		int dcount = 0;
		if(itemPosition.x >= .95f || itemPosition.x < -.38f || itemPosition.y > .95f || itemPosition.y < -.361f)
		{
			return newObject;
		}


		for(int i =0; i < destroyed.Count; i++)
		{
			if((Vector3)destroyed[i] == itemPosition)
			{
				return newObject;
			}
		}
		bool breakif = false;
		int count = posGrid.Count;
		while(count > 0)
		{
			for(int i = 0; i < (posGrid[posGrid.Count-count].Count); i++)
			{
				for(int j = 0; j < (posGrid[posGrid.Count-count][i].Count); j++)
				{
					if(posGrid[posGrid.Count-count][i][j] != null && posGrid[posGrid.Count-count][i][j].getPosition() == itemPosition)
					{
						return newObject;
					}
					if(!breakif && posGrid[posGrid.Count-count][i][j].getPosition() == oldPosition)
					{
						decay = posGrid[0][i][j].getDecay();
						dcount = posGrid[0][i][j].getCount();
						found = true;
						breakif = true;
						break;
					}
					else if(!breakif && posGrid[posGrid.Count-count][i][j].getPosition() == zeroposition)
					{
						decay = posGrid[0][i][j].getDecay();
						dcount = posGrid[0][i][j].getCount();
						found = false;
						breakif = true;
						break;
					}
				}
			}
			count--;
		}
	
		cc = newObject.GetComponent<CubeController> ();
		newObject.transform.position = itemPosition;
		newObject.transform.rotation = itemRotation;

		float vectory = 0;
		float vectorz = 0;
		if(itemPosition.x >= 0)
		{
			vectory = itemPosition.x/cubeDim;
			vectory = 50f - vectory;
		}
		else
		{
			vectory = (itemPosition.x*(-1))/cubeDim + 49f;
		}
		if(itemPosition.y > 0)
		{
			vectorz = itemPosition.y/cubeDim;
			vectorz = 50f - vectorz;
		}
		else
		{
			vectorz = (itemPosition.y*(-1))/cubeDim + 49f;
		}
		
		Vector3 listPos = new Vector3 ((int)(itemPosition.z / cubeDim), vectory, vectorz);
		Vox myVox = new Vox(itemPosition, listPos, (int)(itemPosition.z/cubeDim), newObject);

		if(found)
		{
			if(decay > 0)
			{
				if(decay == 4 && dcount == 1)
				{
					cc.setCount(3);
					myVox.setCount(3);
				}
				else if(decay == 3 && dcount == 1)
				{
					cc.setCount(3);
					myVox.setCount(3);
				}
				else if(decay == 2 && dcount == 1)
				{
					cc.setCount(2);
					myVox.setCount(2);
				}
				else if(decay == 1 && dcount == 1)
				{
					cc.setCount(0);
					myVox.setCount(0);
				}
				else if(decay == 0)
				{
					cc.setCount(0);
					myVox.setCount(0);
				}
				else
				{
					cc.setCount(dcount-1);
					myVox.setCount(dcount-1);
				}
				if(dcount == 1)
				{
					cc.setMaterial(decay-1);
					myVox.setDecay (decay-1);
				}
				else if(dcount > 1)
				{
					cc.setMaterial(decay);
					myVox.setDecay(decay);
				}
				else
				{
					cc.setMaterial(0);
					myVox.setDecay(0);
				}
			}
			else
			{
				cc.setMaterial(0);
				cc.setCount(0);
				myVox.setCount(0);
				myVox.setDecay (0);
			}
		}
		else
		{
			int multiple = (int)(itemPosition.z/cubeDim);
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
		}

		if(((int)myVox.getListPos().x) > posGrid.Count-1)
		{
			innerList = new List<Vox>();
			midList = new List<List<Vox>>();
			innerList.Add(myVox);
			midList.Add(innerList);
			posGrid.Add(midList);
		}
		else if((int)myVox.getListPos().y > posGrid[(int)myVox.getListPos().x].Count-1)
		{
			innerList = new List<Vox>();
			midList = new List<List<Vox>>();
			innerList.Add(myVox);
			midList.Add(innerList);
			posGrid.Insert((int)myVox.getListPos().x, midList);
		}
		else if((int)myVox.getListPos().z > posGrid[(int)myVox.getListPos().x][(int)myVox.getListPos().y].Count-1)
		{
			innerList = new List<Vox>();
			innerList.Add(myVox);
			midList = posGrid[(int)myVox.getListPos().x];
			midList.Insert((int)myVox.getListPos().x, innerList);
			posGrid.Insert((int)myVox.getListPos().x, midList);
		}
		cc.setLevel ((int)(itemPosition.z / .019f));
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
