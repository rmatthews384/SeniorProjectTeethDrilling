using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecayPropagation : MonoBehaviour {

	PoolingSystem ps;
	CubeController cc;
	Queue<Vox> next = new Queue<Vox>();
	List<Vox> finished = new List<Vox>();


	// Use this for initialization
	void Start () {
		ps = GameObject.FindGameObjectWithTag("APS").GetComponent<PoolingSystem>();
		List<Vox> heavyDecay = ps.heavyDecay;

		foreach(Vox value in heavyDecay)
		{
			int i = 0;
			int x = 0;
			int y = (int)value.getListPos().y;
			int z = (int)value.getListPos().z;
			next = new Queue<Vox>();
			Vox myvox;
			next.Enqueue(value);
			finished.Add(value);
			while(i < 81 && next.Count > 0)
			{
				myvox = next.Dequeue();
				x = 0;
				y = (int)myvox.getListPos().y;
				z = (int)myvox.getListPos().z;
				int newY = y - 1;
				int newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				newY = y + 1;
				newZ = z +1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				newY = y - 1;
				newZ = z + 1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				newY = y + 1;
				newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				newY = y;
				newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				newZ = z + 1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}

				newY = y + 1;
				newZ = z;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				newY = y - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 69 && newZ <= 69 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					next.Enqueue(ps.posGrid[x][newY][newZ]);
					cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
					if(myvox.getDecay()-1 > 0)
					{
						cc.setMaterial(myvox.getDecay()-1);
						ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
					}
					else
					{
						cc.setMaterial(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				i++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
