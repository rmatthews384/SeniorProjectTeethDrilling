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
	static ArrayList destroyed = new ArrayList();
	
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
				for(int k = 0; k < 70; k++)
				{
					startvector.x -= .019f;
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
				midList.Add(innerList);
				innerList = new List<Vox>();
				startvector.y -= .019f;
			}
		}
		posGrid.Add (midList);
		Debug.Log (posGrid.Count);
		for(int i = 0; i < 100; i++)
		{
			int x = Random.Range(3,67);
			int y = Random.Range(3,67);
			Vox myVox = posGrid[0][x][y];
			myVox.setDecay(4);
			GameObject vox = myVox.getVox();
			cc = vox.GetComponent<CubeController>();
			cc.setMaterial(4);
			heavyDecay.Add(myVox);
		}
		Instantiate (Resources.Load ("decay"));
	}

	
	
	public static void DestroyAPS(GameObject myObject)
	{
		destroyed.Add (myObject.transform.position);
		myObject.SetActive(false);
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
		Vector3 newposition = itemPosition;
		newposition.z -= .019f;
		if(itemPosition.x > .95f || itemPosition.x < -.95f || itemPosition.y > .95f || itemPosition.y < -.95f)
		{
			return newObject;
		}


		for(int i =0; i < destroyed.Count; i++)
		{
			Vector3 x = (Vector3)destroyed[i];
			if((Vector3)destroyed[i] == itemPosition)
			{
				return newObject;
			}
		}
	
		cc = newObject.GetComponent<CubeController> ();
		newObject.transform.position = itemPosition;
		newObject.transform.rotation = itemRotation;

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
