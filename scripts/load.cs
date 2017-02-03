using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class load : MonoBehaviour {

	public string leveln;
	
	void OnMouseDown() {
		Application.LoadLevel(leveln);
	}

	public void inMenu(){
		Time.timeScale = 1; 
		Application.LoadLevel("main");
	}

	void OnMouseEnter(){
		this.gameObject.transform.position -= new Vector3 (0.04f,0,0);
	}

	void OnMouseExit(){
		this.gameObject.transform.position += new Vector3 (0.04f,0,0);
	}
}
