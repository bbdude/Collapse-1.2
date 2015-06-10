using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
	public Slider slider;
	public GameObject[] panels;
	public KeyCode[] keys;
	//public int thisValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		panels[(int)slider.value].SetActive(true);
		if (Input.GetKeyDown(keys[0]))
		{
			
			slider.value = 0;
		}
		else if (Input.GetKeyDown(keys[1]))
		{
			slider.value = 1;
		}
	}

	public void deactivePanels()
	{
		for (int i = 0; i < panels.Length; i++)
		{
			panels[i].SetActive(false);
		}
	}
}
