using UnityEngine;
using System.Collections;

public class ItemDropScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.name == "Player")
		{
			Destroy(this.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		Vector3 newRotation = transform.rotation.eulerAngles;
		//Vector3 newPosition = transform.position;
		if (transform.rotation.eulerAngles.y >= 360)
		{
			newRotation.y -= 360;
		}
		newRotation.y += 20 * Time.deltaTime;
		//newPosition.y -= 0.1f * Time.deltaTime;
		
		transform.rotation = Quaternion.Euler(newRotation);
		//transform.position = newPosition;
		//this.transform.rotation.eulerAngles.Set(0,this.transform.rotation.eulerAngles.y + 10,0);
		//this.transform.Rotate(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y + 0.1f,this.transform.rotation.eulerAngles.z);
		//this.transform.rotation.eulerAngles.Set(this.transform.rotation.eulerAngles.x + Time.deltaTime,this.transform.rotation.eulerAngles.y,this.transform.rotation.eulerAngles.z);
	}
}
