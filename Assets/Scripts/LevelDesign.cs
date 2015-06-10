using UnityEngine;
using System.Collections;
public class LevelDesign : MonoBehaviour {
	
	public GameObject dirt;
	public GameObject grass;
	public GameObject water;
	public GameObject stone;
	public GameObject wood;

	public GameObject sun;
	public GameObject player;

	[Range(0,100)]
	public int levelWidth;
	//[Range(0,7)]
	//public int baseLevelHeight;
	[Range(0,50)]
	public int maxGeneratedHeight;
	[Range(0,7)]
	public int minLevelHeight;
	[Range(0,50)]
	public int minPeakHeight;
	[Range(0,5)]
	public int maxNumbPeaks;
	[SerializeField]
	public GameObject[,,] cubes;

	/*// Use this for initialization
	IEnumerator EnableLandScript(int distance, float refreshTime)
	{
		ELSRunning = true;
		int px = (int)player.transform.position.x;
		int pz = (int)player.transform.position.z;

		int tempx = px - (levelWidth/2);
		int tempz = pz - (levelWidth/2);
		if (tempx < 0)
			tempx = 0;
		if (tempz < 0)
			tempz = 0;

		for (int i = 0; i < levelWidth; i++)
		{
			for(int ii = 0; ii < maxGeneratedHeight;ii++)
			{
				if (cubes[tempx,ii,tempz + i] != null)
					cubes[tempx,ii,tempz + i].SetActive(false);
				

			}
		}
		yield return null;
		for (int i = 0; i < levelWidth; i++)
		{
			for(int ii = 0; ii < maxGeneratedHeight;ii++)
			{
				if (cubes[tempx + i,ii,tempz] != null)
					cubes[tempx + i,ii,tempz].SetActive(false);

			}
		}
		yield return null;
		ELSRunning = false;
		yield return null;
	}*/

		public GameObject Dirt
	{
		get {return dirt;}
		set {dirt = value;}
	}public GameObject Grass
	{
		get {return grass;}
		set {grass = value;}
	}public GameObject Water
	{
		get {return water;}
		set {water = value;}
	}public GameObject Stone
	{
		get {return stone;}
		set {stone = value;}
	}public GameObject Wood
	{
		get {return wood;}
		set {wood = value;}
    }
    
    void Start () {
		this.transform.position = new Vector3(levelWidth/2,0,levelWidth/2);
		sun.transform.position = new Vector3(levelWidth/2,sun.transform.position.y,levelWidth/2);
		player.transform.position = new Vector3(levelWidth/2,sun.transform.position.y,levelWidth/2);

		cubes = new GameObject[levelWidth * 2,maxGeneratedHeight,levelWidth * 2];



		for (int i = 0; i < maxNumbPeaks; i++)
		{

			Vector3 peakPoint = new Vector3(Random.Range(0,levelWidth),Random.Range(minPeakHeight,maxGeneratedHeight),Random.Range(0,levelWidth));

			if (cubes[(int)peakPoint.x,(int)peakPoint.y,(int)peakPoint.z] != null)
				return;

			//cubes[(int)peakPoint.x,(int)peakPoint.y,(int)peakPoint.z] = (GameObject)Instantiate(grass,peakPoint,Quaternion.Euler(0,0,0));
			//cubes[(int)peakPoint.x,(int)peakPoint.y,(int)peakPoint.z].name = "Peak" + i.ToString();

			int distance = 0;
			for(int ii = ((int)peakPoint.y) - 1; ii > minLevelHeight; ii--)
			{
				Vector3 newPos = peakPoint;
				int ppy = (int)(peakPoint.y - ii) - 1;
				//newPos.y = ii;


				for (int x = (int)((peakPoint.y - ii - 1) * -1); x < (peakPoint.y - ii); x++)
				{
					for (int z = (int)((peakPoint.y - ii - 1) * -1); z < (peakPoint.y - ii); z++)
					{
						newPos = new Vector3(peakPoint.x + x,ii,peakPoint.z + z);

						if (newPos.x < 0 || newPos.x > levelWidth - 1 || newPos.z < 0 || newPos.z > levelWidth - 1) 
						{
						}
						else
						{
							if (x == ppy || x == ppy * -1 || z == ppy || z == ppy * -1)// || (z == 0 && x == 0))
							{
								
								if (Random.Range(0,22) == 4)
									break;
								if (cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z] == null)
								{
									Destroy(cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z]);
								}
								cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z] = (GameObject)Instantiate(grass,newPos,Quaternion.Euler(0,0,0));
								cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z].name = "Grass " + newPos.x.ToString() + "," + newPos.y.ToString() + "," + newPos.z.ToString();
							}
							else
							{
								if (cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z] == null)
								{
									Destroy(cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z]);
								}
								cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z] = (GameObject)Instantiate(dirt,newPos,Quaternion.Euler(0,0,0));
								cubes[(int)newPos.x,(int)newPos.y,(int)newPos.z].name = "Dirt " + newPos.x.ToString() + "," + newPos.y.ToString() + "," + newPos.z.ToString();
							}

						}

					}
				}
			}

		}
		Vector3 tempPosition = new Vector3(0,0,0);

		
		for (int i = 0; i < levelWidth; i++)
		{
			for (int ii = 0; ii < levelWidth; ii++)
			{
				for (int iii = 0; iii <= minLevelHeight; iii++)
				{
					if (iii == minLevelHeight)
					{
						if (cubes[i,iii,ii] == null)
						{
							//if (Random.Range(0 + i,18 + ii) != 4)
							//{
								//Random.seed = (int)Time.deltaTime;
							/*if (cubes[i,iii,ii] != null)
							{
								Destroy(cubes[i,iii,ii]);
							}*/
							tempPosition = new Vector3(i,iii,ii);
							cubes[i,iii,ii] = (GameObject)Instantiate(grass,tempPosition,Quaternion.Euler(0,0,0));
							
							cubes[i,iii,ii].name = "Grass " + i.ToString() + "," + iii.ToString() + "," + ii.ToString();
							//}
						}
					}
					else
					{
						if (cubes[i,iii,ii] == null)
						{
							tempPosition = new Vector3(i,iii,ii);
							if (cubes[i,iii,ii] != null)
							{
								Destroy(cubes[i,iii,ii]);
							}
							cubes[i,iii,ii] = (GameObject)Instantiate(dirt,tempPosition,Quaternion.Euler(0,0,0));
							
							cubes[i,iii,ii].name = "Dirt " + i.ToString() + "," + iii.ToString() + "," + ii.ToString();
						}
					}
				}
			}
		}

		/*for (int i = 0; i < levelWidth; i++)
		{
			for (int ii = 0; ii < levelWidth; ii++)
			{
				if (cubes[i,minLevelHeight,ii] == null)
				{
					tempPosition = new Vector3(i,minLevelHeight,ii);
					cubes[i,minLevelHeight,ii] = (GameObject)Instantiate(grass,tempPosition,Quaternion.Euler(0,0,0));

					cubes[i,minLevelHeight,ii].name = "Grass " + i.ToString() + "," + minLevelHeight.ToString() + "," + ii.ToString();
				}
			}
		}*/
		
		tempPosition = new Vector3(levelWidth/2,minLevelHeight + 1,levelWidth/2);

		for(int i = ((levelWidth/2)-4); i < ((levelWidth/2)+4); i++)
		{
			for(int ii = ((levelWidth/2)-4); ii < ((levelWidth/2)+4); ii++)
			{
				for (int iii = minLevelHeight + 1;iii < maxGeneratedHeight; iii++)
					Destroy(cubes[i,iii,ii]);
			}
		}
		for(int i = ((levelWidth/2)-2); i < ((levelWidth/2)+2); i++)
		{
			for(int ii = ((levelWidth/2)-2); ii < ((levelWidth/2)+2); ii++)
			{

				//if ((i == 40 && ii == 41) ||(i == 40 && ii == 40) ||(i == 40 && ii == 39) ||(i == 39 && ii == 39) ||(i == 39 && ii == 40))
				if ((i == (levelWidth/2) && ii == (levelWidth/2) + 1) ||(i == (levelWidth/2) && ii == (levelWidth/2)) ||(i == (levelWidth/2) && ii == (levelWidth/2) - 1) ||(i == (levelWidth/2) - 1 && ii == (levelWidth/2) - 1) ||(i == (levelWidth/2) - 1 && ii == (levelWidth/2)))
				{
					//Roof
					tempPosition = new Vector3(i,minLevelHeight + 3,ii);
					if (cubes[i,minLevelHeight + 3,ii] == null)
					{
						Destroy(cubes[i,3,ii]);
					}
					cubes[i,minLevelHeight + 3,ii] = (GameObject)Instantiate(wood,tempPosition,Quaternion.Euler(0,0,0));
					cubes[i,minLevelHeight + 3,ii].name = "Wood " + i.ToString() + "," + (minLevelHeight + 3).ToString() + "," + ii.ToString();

				}
				else
				{
					if (cubes[i,minLevelHeight + 1,ii] == null)
					{
						Destroy(cubes[i,minLevelHeight + 1,ii]);
					}

					tempPosition = new Vector3(i,minLevelHeight + 1,ii);
					cubes[i,minLevelHeight + 1,ii] = (GameObject)Instantiate(wood,tempPosition,Quaternion.Euler(0,0,0));
					cubes[i,minLevelHeight + 1,ii].name = "Wood " + i.ToString() + "," + (minLevelHeight + 1).ToString() + "," + ii.ToString();

					if (cubes[i,2,ii] == null)
					{
						Destroy(cubes[i,2,ii]);
					}
					tempPosition = new Vector3(i,minLevelHeight + 2,ii);
					cubes[i,minLevelHeight + 2,ii] = (GameObject)Instantiate(wood,tempPosition,Quaternion.Euler(0,0,0));
					cubes[i,minLevelHeight + 2,ii].name = "Wood " + i.ToString() + "," + (minLevelHeight + 2).ToString() + "," + ii.ToString();
				}
			}
		}
		//cubes[levelWidth/2,minLevelHeight + 1,levelWidth/2] = (GameObject)Instantiate(wood,tempPosition,Quaternion.Euler(0,0,0));
		
		//StartCoroutine(EnableLandScript(0,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}









