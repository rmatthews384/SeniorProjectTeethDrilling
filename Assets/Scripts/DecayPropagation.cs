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
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
						
						if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
						{
							cc.setMaterial(myvox.getDecay()-1);
							ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
							if(myvox.getDecay() == 4)
							{
								ps.posGrid[x][newY][newZ].setCount(3);
							}
							else if(myvox.getDecay() == 3)
							{
								ps.posGrid[x][newY][newZ].setCount(3);
							}
							else if(myvox.getDecay() == 2)
							{
								ps.posGrid[x][newY][newZ].setCount(2);
							}
							else if(myvox.getDecay() == 1)
							{
								ps.posGrid[x][newY][newZ].setCount(0);
							}
							else
							{
								ps.posGrid[x][newY][newZ].setCount(0);
							}
						}
					}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//top right
				newY = y + 1;
				newZ = z +1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//top left
				newY = y - 1;
				newZ = z + 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//bottom left
				newY = y + 1;
				newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//bottom
				newY = y;
				newZ = z - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//top
				newZ = z + 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//right
				newY = y + 1;
				newZ = z;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
					}
					finished.Add(ps.posGrid[x][newY][newZ]);
				}
				//left
				newY = y - 1;
				if(newY >= 0 && newZ >= 0 && newY <= 34 && newZ <= 34 && !finished.Contains(ps.posGrid[x][newY][newZ]))
				{
					if(newY > 5 || (newY == 0 && newZ >= 6 && newZ < 29) || (newY == 1 && newZ >= 5 && newZ < 30) ||
					   (newY == 2 && newZ >= 4 && newZ < 31)|| (newY == 3 && newZ >= 3 && newZ < 32)|| 
					   (newY == 4 && newZ >= 2 && newZ < 33) || (newY == 5 && newZ >= 1 && newZ < 34))
					{
						if(ps.posGrid[x][newY][newZ] != null)
						{
							next.Enqueue(ps.posGrid[x][newY][newZ]);
							cc = ps.posGrid[x][newY][newZ].getVox().GetComponent<CubeController>();
							
							if(myvox.getDecay()-1 > 0 && cc.getDecay() == 0)
							{
								cc.setMaterial(myvox.getDecay()-1);
								ps.posGrid[x][newY][newZ].setDecay(myvox.getDecay()-1);
								if(myvox.getDecay() == 4)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 3)
								{
									ps.posGrid[x][newY][newZ].setCount(3);
								}
								else if(myvox.getDecay() == 2)
								{
									ps.posGrid[x][newY][newZ].setCount(2);
								}
								else if(myvox.getDecay() == 1)
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
								else
								{
									ps.posGrid[x][newY][newZ].setCount(0);
								}
							}
						}
					}
					else if(cc.getDecay() != 4 && ps.posGrid[x][newY][newZ] != null)
					{
						cc.setMaterial(0);
						ps.posGrid[x][newY][newZ].setDecay(0);
						ps.posGrid[x][newY][newZ].setCount(0);
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
