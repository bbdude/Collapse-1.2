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
	/* Update is called once per frame
	void Update () {
		Vector3 newRotation = transform.rotation.eulerAngles;
		//Vector3 newPosition = transform.position;
		if (transform.rotation.eulerAngles.y >= 360)
		{
			newRotation.y -= 360;
		}
		newRotation.y += 20 * Time.deltaTime;
		
		transform.rotation = Quaternion.Euler(newRotation);
	}*/
}
