using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {

	// Use this for initialization

	public Transform pointOfRotation;
	//Takes about 4secs on 1
	[Range(0.001f,1)]
	public float timeToRotate;

	public bool rotate = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate)
			this.transform.RotateAround(pointOfRotation.position,Vector3.left,timeToRotate);
	}
}
