using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int scr = 0;

	void OnGUI() { 		
		GUI.Label(new Rect(10, 40, 150, 100), "Score: " + scr); 
	}
}
