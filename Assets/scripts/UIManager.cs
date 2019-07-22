using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
	public static UIManager instance;
	public GameObject ZigzagPanel;
	public GameObject gameOverPanel;
	public GameObject TapText;
	public Text score;
	public Text Highscore1;
	public Text Highscore2;
	// Use this for initialization
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	void Start () {
		Highscore1.text = "High Score:" + PlayerPrefs.GetInt ("HighScore");
	}
	public void GameStart(){
		TapText.SetActive (false);
		ZigzagPanel.GetComponent<Animator> ().Play ("Panel");
	}
	public void GameOver(){
		score.text = PlayerPrefs.GetInt ("Score").ToString();
		Highscore2.text = PlayerPrefs.GetInt ("HighScore").ToString();
		gameOverPanel.SetActive (true);
	}
	public void Reset(){
		SceneManager.LoadScene (0);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
