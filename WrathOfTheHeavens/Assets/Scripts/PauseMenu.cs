using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	
	public GUISkin skin;

	private float startTime = 0.1f;
	
	public Material mat;

	private float savedTimeScale;
	
	public GameObject start;
	
	public string[] instructions= {
		"Kill the zombies, before they reach the town!",
		"Use the F key to fire a lightning bolt."} ;
	public Texture[] instructionsIcons;
	
	public enum Page {
		None,Main,Instructions
	}
	
	private Page currentPage;
	
	
	void Start() {
		Time.timeScale = 1;
		PauseGame();
	}
	
	void LateUpdate () {
		
		if (Input.GetKeyDown("escape")) 
		{
			switch (currentPage) 
			{
			case Page.None: 
				PauseGame(); 
				break;
				
			case Page.Main: 
				if (!IsBeginning()) 
					UnPauseGame(); 
				break;
				
			default: 
				currentPage = Page.Main;
				break;
			}
		}
	}
	
	void OnGUI () {
		if (skin != null) {
			GUI.skin = skin;
		}
		if (IsGamePaused()) {
			switch (currentPage) {
			case Page.Main: MainPauseMenu(); break;
			case Page.Instructions: ShowInstructions(); break;
			}
		}   
	}
	
	void ShowInstructions() {
		BeginPage(200,200);
		foreach(string inst in instructions) {
			GUILayout.Label(inst);
		}
		foreach( Texture icon in instructionsIcons) {
			GUILayout.Label(icon);
		}
		EndPage();
	}
	
	void ShowBackButton() {
		if (GUI.Button(new Rect(150, Screen.height - 50, 50, 20),"Back")) {
			currentPage = Page.Main;
		}
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}
	
	bool IsBeginning() {
		return (Time.time < startTime);
	}	
	
	void MainPauseMenu() {
		BeginPage(200,200);
		if (GUILayout.Button (IsBeginning() ? "Play" : "Continue")) {
			UnPauseGame();
			
		}
		if (GUILayout.Button ("Instructions")) {
			currentPage = Page.Instructions;
		}
		if (!IsBeginning() && GUILayout.Button ("Reset")) {
			Application.LoadLevel(0);
		}
		if  (GUILayout.Button ("Exit")) {
			Application.Quit();
		}
		EndPage();
	}
	
	void PauseGame() {
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
		currentPage = Page.Main;
		GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	void UnPauseGame() {
		Time.timeScale = savedTimeScale;
		AudioListener.pause = false;
		
		currentPage = Page.None;
		
		if (IsBeginning() && start != null) {
			start.SetActive(true);
		}
		GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<SpriteRenderer> ().enabled = true;
	}
	
	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}
	
	void OnApplicationPause(bool pause) {
		if (IsGamePaused()) {
			AudioListener.pause = true;
		}
	}
}