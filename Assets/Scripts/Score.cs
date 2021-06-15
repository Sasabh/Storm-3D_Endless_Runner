using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

	private float score = 0.0f;
	private float dLevel = 1.0f;
	private int maxdLevel = 40;
	private int scoreToNextLevel = 10;
	public Text ScoreText;
	private bool isDead = false;
	public Menu menu;
	void Start () {
	}
	void Update () {
		if (isDead)
			return;

		if (score >= scoreToNextLevel)
			LevelUp ();

		score += Time.deltaTime * dLevel;
		ScoreText.text = ((int)score).ToString ();
	}

	void LevelUp(){
		scoreToNextLevel *= 2;
		if (dLevel <= maxdLevel) {
			dLevel++;
			GetComponent<PlayerMotor> ().SetSpeed (dLevel);
		}
	}
	public void OnDeath(){
		isDead = true;
		menu.ToggleEndMenu (score);
	}
}
