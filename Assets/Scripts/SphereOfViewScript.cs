using UnityEngine;
using System.Collections;

public class SphereOfViewScript : MonoBehaviour {

	void OnTriggerEnter ( Collider obj) {
		//if (obj.gameObject.tag != "SphereOfView") { // makes sure object is not a car, don't want to disable that
			//obj.gameObject.SetActive(true);
		Renderer ren = obj.gameObject.GetComponent<Renderer>();
		ren.enabled = true;
		if (obj.gameObject.tag == "Block")
		{
			BlockScript bls = obj.gameObject.GetComponent<BlockScript>();
			bls.enabled = true;
		}
		//}
	}
	void  OnTriggerExit ( Collider obj){
		Renderer ren = obj.gameObject.GetComponent<Renderer>();
		ren.enabled = false;
		if (obj.gameObject.tag == "Block")
		{
			BlockScript bls = obj.gameObject.GetComponent<BlockScript>();
			bls.enabled = false;
		}
		//if (obj.gameObject.tag != "SphereOfView"){
		//obj.gameObject.SetActive(false);
		//}
	}
}
