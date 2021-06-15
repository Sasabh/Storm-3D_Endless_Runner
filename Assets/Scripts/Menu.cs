using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Text scoreText;
	public Image backgroundImg;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleEndMenu(float score){
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString();
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void ToMenu(){
		SceneManager.LoadScene("Menu");
	}
	public void Quit(){
		Application.Quit();
	}
}
