﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
	public GameObject platform;
	public GameObject Diamond;
	Vector3 lastPos;
	float  size;
	public bool gameOver;
	// Use this for initialization
	void Start () {
		lastPos = transform.position;
		size = transform.localScale.x;
		for (int i = 0; i < 20; i++) {
			SpawnPlatform ();
		}
	}
	public void StartSpawningPlatforms(){
		InvokeRepeating ("SpawnPlatform", .1F, 0.2F);
	}
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver == true) {
			CancelInvoke ("SpawnPlatform");
		}
	}
	void SpawnPlatform(){
		int randomNumber = Random.Range (0, 6);
		if (randomNumber < 3) {
			SpawnX ();
		} else if (randomNumber >= 3) {
			SpawnZ ();
		}
	}

	void SpawnX(){
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate(Diamond, new Vector3(pos.x,.5f,pos.z),Diamond.transform.rotation);
		}
	}
	void SpawnZ(){
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate(Diamond, new Vector3(pos.x,.5f,pos.z),Diamond.transform.rotation);
		}
	}
}
