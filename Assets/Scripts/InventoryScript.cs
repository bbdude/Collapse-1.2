using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
[SerializeField]
public class toolIVT
{
	public int durability;
	public int strength;
};
[System.Serializable]
public class InventoryScript : MonoBehaviour {

	// Use this for initialization
	
	//public List<int> dirtIV = new List<int>(); 
	//public List<int> stoneIV = new List<int>(); 
	//public List<int> torchIV = new List<int>(); 
	public int dirt = 0;
	public int stone = 0;
	public int torch = 0;
	public List<toolIVT> swordIV 	= new List<toolIVT>(); 
	public List<toolIVT> pickIV 	= new List<toolIVT>(); 
	public List<toolIVT> axeIV 	= new List<toolIVT>(); 
	public List<toolIVT> shovelIV 	= new List<toolIVT>(); 
	public Text[] count;

	public void addInventory(string type, int amount)
	{
		switch(type)
		{
		case "Dirt":
			dirt += amount;
			count[0].text = dirt.ToString();
            //Debug.LogWarning("Inv Full");
            break;
		case "Torch":
			torch += amount;
			//count[5].text = dirt.ToString();
            break;
		case "Stone":
			stone += amount;
			count[1].text = stone.ToString();
			break;
		case "Shovel":

			shovelIV.Add(new toolIVT());
			shovelIV[shovelIV.Count - 1].durability = 10;
			shovelIV[shovelIV.Count - 1].strength = 2;

			Debug.LogWarning("Shovel Added");
			break;
		case "Axe":

			axeIV.Add(new toolIVT());
			axeIV[axeIV.Count - 1].durability = 10;
			axeIV[axeIV.Count - 1].strength = 2;

			Debug.LogWarning("Axe Added");
			break;
		case "PickAxe":

			pickIV.Add(new toolIVT());
			pickIV[pickIV.Count - 1].durability = 10;
			pickIV[pickIV.Count - 1].strength = 2;

			Debug.LogWarning("PickAxe Added");
			break;
		case "Sword":

			swordIV.Add(new toolIVT());
			swordIV[swordIV.Count - 1].durability = 10;
			swordIV[swordIV.Count - 1].strength = 2;

			Debug.LogWarning("Sword Added");
			break;
}
    }
    public bool takeInventory(string type, int amount)
	{

		return true;
	}
	public void adjustDurability(string type, int amount)
	{
	}

	void Start () 
	{
		addInventory("Dirt",5);
		addInventory("Stone",5);
		addInventory("Torch",9);
		addInventory("Shovel",1);
		addInventory("Sword",1);
		addInventory("Axe",1);
		addInventory("Pick",1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = shovelIV.Count - 1; i >= 0; i--)
		{
			if (shovelIV[i].durability <= 0)
			{
				shovelIV.Remove(shovelIV[i]);
				Debug.LogWarning("Shovel Removed");
			}
        }
		for(int i = swordIV.Count - 1; i >= 0; i--)
		{
			if (swordIV[i].durability <= 0)
			{
				swordIV.Remove(swordIV[i]);
				Debug.LogWarning("Sword Removed");
			}
        }
		for(int i = pickIV.Count - 1; i >= 0; i--)
		{
			if (pickIV[i].durability <= 0)
			{
				pickIV.Remove(pickIV[i]);
				Debug.LogWarning("Pick Removed");
			}
        }
		for(int i = axeIV.Count - 1; i >= 0; i--)
		{
			if (axeIV[i].durability <= 0)
			{
				axeIV.Remove(axeIV[i]);
				Debug.LogWarning("Axe Removed");
			}
        }
	}
}
