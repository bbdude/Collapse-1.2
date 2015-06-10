using UnityEngine;
using System;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

public class TextChangedScript : MonoBehaviour {

	public Text[] counts;
	public Text finalCount;
	void collective()
	{
		int r = 0;
		for (int i = 0; i < counts.Length;i++)
		{
			r += int.Parse(counts[i].text);
		}
		finalCount.text = r.ToString() + "/ 100";
	}
}
