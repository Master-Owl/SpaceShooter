using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuNavigations : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadSceneByName(string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitApplication() {
		if (Application.isEditor)
			EditorApplication.isPlaying = false;
		else 
			Application.Quit();		
	}
}
