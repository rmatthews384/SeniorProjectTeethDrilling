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
		//ps = PoolingSystem.Instance;
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
			while(next.Count > 0)
			{
				myvox = next.Dequeue();
				x = 0;
				y = (int)myvox.getListPos().y;
				z = (int)myvox.getListPos().z;
				//bottom left
				int newY = y - 1;
				int newZ = z - 1; 
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
						
						if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
						{
							cc.setMaterial(myvox.getDecay()-1);
							ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);

						}
					
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//top right
				newY = y + 1;
				newZ = z +1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);

							}
						}

					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//top left
				newY = y - 1;
				newZ = z + 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);

							}
						}
					
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//bottom left
				newY = y + 1;
				newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);

							}
						}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//bottom
				newY = y;
				newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
							}
						}

					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//top
				newZ = z + 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
							}
						}

					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//right
				newY = y + 1;
				newZ = z;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								
							}
						}

					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//left
				newY = y - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() != 4)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								
							}
						}

					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				i++;
			}
		}
		ps.calcTotDecay();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
