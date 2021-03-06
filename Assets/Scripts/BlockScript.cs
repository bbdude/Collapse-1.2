﻿using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	// Use this for initialization
	public Material[] materials;
	public int breakTime = 100;
	float secsWithoutDmg = 0;
	float secsWithoutLook = 3;
	public Renderer rend;
	public GameObject drop;
	private int currentRender = -1;

	void Start() {
		rend = GetComponent<Renderer>();
		//rend.enabled = true;
	}

	// Update is called once per frame
	void Update () {
	
		if (secsWithoutLook < 0.2f)
		{
			if (currentRender != 2)
				rend.material = materials[2];
			currentRender = 2;
		}
		else
		{
			if (currentRender != 0)
				rend.material = materials[0];
			currentRender = 0;
		}
		if (breakTime < 100)
		{
			secsWithoutDmg += 0.1f;
			if (currentRender != 1)
				rend.material = materials[1];
			currentRender = 1;
		}

		if (secsWithoutDmg > 0.3f)
		{
			breakTime = 100;
			
			if (currentRender != 0)
				rend.material = materials[0];
			currentRender = 0;
		}

		if (breakTime <= 0)
		{
			GameObject tempDrop = (GameObject)Instantiate(drop,this.transform.position,Quaternion.Euler(0,0,0));
			Renderer tempRend  = tempDrop.GetComponent<Renderer>();
			tempRend.material = rend.material;
			rend.enabled = true;
			tempDrop.name = "Dirt";
			Destroy(this.gameObject);
		}
		if (secsWithoutLook < 3)
			secsWithoutLook += 0.1f;

	}

	void Break(int modifier)
	{
		if (breakTime > 0)
		{
			secsWithoutDmg = 0;
			breakTime -= modifier;
		}
	}
	void LookedAt()
	{
		if (breakTime == 100)
		{
			secsWithoutLook = 0;

		}
	}
}
