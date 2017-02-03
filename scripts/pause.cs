using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
	private bool paused = false;
	private GameObject canv;

	void Start(){
		canv = GameObject.Find ("Pause");
		canv.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused) {
			Time.timeScale = 0; 
			paused = true;
			Cursor.visible = true;
			if (canv) {				
				if (!canv.activeSelf) {
					canv.SetActive (true);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.Escape) && paused) {
			Time.timeScale = 1.0f;
			paused = false;
			Cursor.visible = false;
			if (canv) {
				if (canv.activeSelf) {
					canv.SetActive (false);
				}
			}
		}
	
	}

	public void exPaused(){
		Time.timeScale = 1.0f;
		paused = false;
		Cursor.visible = false;
		if (canv) {
			if (canv.activeSelf) {
				canv.SetActive (false);
			}
		}
		
	}
}
