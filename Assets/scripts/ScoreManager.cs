using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;
	public int score;
	public int highscore;
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("Score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void IncrementScore(){
		score += 1;
	}
	public void Startscore(){
		InvokeRepeating ("IncrementScore", 0.1f, 0.5f);
	}
	public void StopScore(){
		CancelInvoke ("IncrementScore");
		PlayerPrefs.SetInt ("Score", score);
		if (PlayerPrefs.HasKey ("HighScore")) {
			if (score > PlayerPrefs.GetInt ("HighScore")) {
				PlayerPrefs.SetInt ("HighScore", score);
			}
		} else {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}
}
