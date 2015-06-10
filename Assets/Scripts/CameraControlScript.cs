using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

	Vector3 lookTarget;
	float speed = 150.0f;
	public bool isCamera = false;
	void Start () {
	
	}

	void Update(){ 
		Vector3 holder = Vector3.zero;
		if (!isCamera)
		{
			holder = new Vector3(0, Input.GetAxis("Mouse X"),0) * Time.deltaTime * speed;
			
			this.transform.Rotate(holder);
			this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y,0);
		}
		else if (isCamera)
		{
			Vector3 euler = this.transform.localEulerAngles;
			if (Input.GetAxis("Mouse Y") != 0)
			{
				euler.x -= speed * Time.deltaTime * Input.GetAxis("Mouse Y");
			}
			/*if (Input.GetAxis("Mouse Y") < 180)
			{
				euler.x += speed * Time.deltaTime * Input.GetAxis("Mouse Y");
			}
			else if (Input.GetAxis("Mouse Y") > 0)
			{
				euler.x += speed * Time.deltaTime * Input.GetAxis("Mouse Y");
			}*/
			euler.y = 0;
			euler.z = 0;
			this.transform.localEulerAngles = euler;
		}

	}
}
