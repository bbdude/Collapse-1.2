using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControlScript : MonoBehaviour {

	public float speed = 6.0f;
	public float inputModifyFactor;
	public float gravity = 20.0f;
	public bool limitDiagonalSpeed = true;
	//public int DirtHeld = 0;
	//public int GrassHeld = 0;
	public GameObject lArm;
	public Transform lArmGP;
	private bool lArmRunning = false;
	public InventoryScript inv;
	public KeyCode invKey;
	public bool invUp = false;
	public PanelScript panel;
	//public RawImage healthUI;
	public int health = 10;
	public int maxHealth = 10;
	public Image[] lHandImages;
	public Image[] rHandImages;
	public KeyCode[] handCode;
	public bool lHandUp = false;
	public bool rHandUp = false;
	public GameObject[] tools;
	public LayerMask invUpLayerMask;
	public LayerMask invDownLayerMask;
	private int currentMask = 0;
	// Use this for initialization

	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "Item")
		{
			if (collider.gameObject.name == "Dirt" || collider.gameObject.name == "Grass")
			{
				inv.addInventory("Dirt",1);
				//DirtHeld++;
				Destroy(collider.gameObject);
			}
		}
	}
	IEnumerator RotateMe(Vector3 byAngles, float inTime) {
		
		var fromAngle = transform.rotation;
		for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
			lArmRunning = true;
			var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
			lArm.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
			yield return null;
			lArmRunning = false;
		}
		StopCoroutine("RotateMe");
	}

	private void moveForward(float speed) {
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}
	
	private void moveBack(float speed) {
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}
	
	private void moveRight(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}
	
	private void moveLeft(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}

	void Update () {
	
		//healthUI.rectTransform.sizeDelta = new Vector2(health/2,health/2);
		//healthUI.SetNativeSize();//.Set(health/5,health/5,health/5);
		//Screen.lockCursor = false;
		//invUp = Input.GetKey(invKey);


		if (Input.GetKeyDown(invKey))
		{
			invUp = !invUp;
			panel.gameObject.SetActive(!panel.gameObject.activeSelf);
			if (currentMask == 0)
			{
				Camera tempCam = GetComponentInChildren<Camera>();
				tempCam.cullingMask = invUpLayerMask;
				currentMask = 1;
			}else if (currentMask == 1)
			{
				Camera tempCam = GetComponentInChildren<Camera>();
				tempCam.cullingMask = invDownLayerMask;
				currentMask = 0;
			}
		}
		if (invUp)
		{
			Screen.lockCursor = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Screen.lockCursor = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			if (Input.GetKeyDown(handCode[0]))
			{
				lHandImages[1].enabled = !lHandImages[1].IsActive();
				lHandImages[2].enabled = !lHandImages[2].IsActive();
				lHandUp = !lHandUp;
			}
			if (Input.GetKeyDown(handCode[1]))
			{
				rHandImages[1].enabled = !rHandImages[1].IsActive();
				rHandImages[2].enabled = !rHandImages[2].IsActive();
				rHandUp = !rHandUp;
			}
		}

		if (lHandUp)
		{
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Sprite tempTex = lHandImages[0].sprite;
				Sprite tempTex2 = lHandImages[1].sprite;
				
				lHandImages[0].sprite = tempTex2;
				lHandImages[1].sprite = tempTex;
				
				tools[0].SetActive(false);
				tools[1].SetActive(true);
				GameObject temp = tools[0];
				tools[0] = tools[1];
				tools[1] = temp;
				Destroy(temp);

			}else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				Sprite tempTex = lHandImages[0].sprite;
				Sprite tempTex2 = lHandImages[2].sprite;
				
				lHandImages[0].sprite = tempTex2;
				lHandImages[2].sprite = tempTex;
				
				tools[0].SetActive(false);
				tools[2].SetActive(true);
				GameObject temp = tools[0];
				tools[0] = tools[2];
				tools[2] = temp;
				Destroy(temp);
			}
		}

		Vector3 newPos = Vector3.zero;
		Rigidbody tempBody;
		tempBody = GetComponent<Rigidbody>();
		
		float up = Input.GetAxis("Up");
		float side = Input.GetAxis("Strafe");
		
		//tempBody.velocity = new Vector3(0, tempBody.velocity.y, 0);
		//tempBody.velocity.z = 0;

		//inputModifyFactor = inputModifyFactor = (up != 0.0 && side != 0.0 && limitDiagonalSpeed)? 0.1f : 1.0f;

		//if (forwordAxis == 0)
		//	Debug.LogWarning("Working");
		if (!invUp)
		{
			moveForward(up * 2);
			moveLeft(side * 2);
		}
		if (Input.GetButtonDown("Jump") && (CollisionFlags.Below) != 0)
			//transform.position += transform.up * (speed * 30) * Time.deltaTime;
			tempBody.velocity += Vector3.up * speed * 110 * Time.deltaTime;//(Vector3.up * speed * 30* Time.deltaTime,ForceMode.Acceleration);

		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		bool rayhit = false;
		if (Physics.Raycast (ray, out hit, 2.0f)) {
			if (hit.collider.tag == "Block") {
				hit.collider.SendMessageUpwards ("LookedAt", SendMessageOptions.DontRequireReceiver);
				rayhit = true;
			}
		}
		if (Input.GetButton("LHand"))
		{
			if (!lArmRunning)
				StartCoroutine(RotateMe(Vector3.right * 60, 0.3f));
			if (rayhit)
				hit.collider.SendMessageUpwards ("Break", 1, SendMessageOptions.DontRequireReceiver);
			/*if (Physics.Raycast (ray, out hit, 2.0f)) {
				if (hit.collider.tag == "Block") {
					hit.collider.SendMessageUpwards ("Break", 1, SendMessageOptions.DontRequireReceiver);
				}
			}*/
		}
		if(Input.GetButtonUp("LHand"))
		{
			StopAllCoroutines();
			lArmRunning = false;
			lArm.transform.rotation = this.transform.rotation;
		}
	}
	
	// Update is called once per frame
	void Start () {

	}
}
