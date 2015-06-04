using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

	Vector3 lookTarget;
	float speed = 150.0f;
	public bool isCamera = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
			/*holder = new Vector3(Input.GetAxis("Mouse Y"), 0,0) * Time.deltaTime * speed;
			
			this.transform.Rotate(holder);
			if (this.transform.rotation.eulerAngles.y > 0)
				this.transform.rotation.eulerAngles.Set(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y,this.transform.rotation.eulerAngles.z);
			if(this.transform.rotation.eulerAngles.x > 180)
			{
				this.transform.rotation.eulerAngles.Set(0,this.transform.rotation.eulerAngles.y,this.transform.rotation.eulerAngles.z);
			}
			if(this.transform.rotation.eulerAngles.x < 180)
			{
				this.transform.rotation.eulerAngles.Set(180,this.transform.rotation.eulerAngles.y,this.transform.rotation.eulerAngles.z);
			}
			this.transform.rotation.eulerAngles.Set(this.transform.rotation.eulerAngles.x,0,this.transform.rotation.eulerAngles.z);
			*/
			/*if(this.transform.rotation.eulerAngles.y > 180)
			{
				this.transform.rotation.eulerAngles.Set(this.transform.rotation.eulerAngles.y,0,this.transform.rotation.eulerAngles.z);
			}
			if(this.transform.rotation.eulerAngles.y < 180)
			{
				this.transform.rotation.eulerAngles.Set(this.transform.rotation.eulerAngles.y,0,this.transform.rotation.eulerAngles.z);
			}*/
			//this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y,0);

		}



		/*if (isCamera)
		{
			//float x = this.transform.rotation.eulerAngles.x;
			
			//Mathf.Clamp(x, -1,1);
			
			this.transform.rotation.eulerAngles.Set(0,0,this.transform.rotation.eulerAngles.z);
		}*/
		//this.transform.rotation.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y,0);
		//this.transform.rotation.eulerAngles.z = 0;
//transform.Rotate(Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)* Time.deltaTime *speed);
	}
}
