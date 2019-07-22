using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	public GameObject particle;
	[SerializeField]
	private float speed;
	private bool gameStarted = false;
	private bool gameOver = false;
	Rigidbody rb;
	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				gameStarted = true;
				GameManager.instance.StartGame ();
			}
		}
		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.velocity = new Vector3 (0, -25f, 0);
			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
			//GetComponent<PlatformSpawner> ().gameOver = true;
			GameManager.instance.GameOver();
		}
		if(Input.GetMouseButtonDown(0) && !gameOver){
			SwitchDirection();
		}
	}
	void SwitchDirection(){
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Diamond") {
			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part,1f);
		}
	}
				
}
