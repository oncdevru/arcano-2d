using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour {
	private bool checkd = false;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Screen.lockCursor = true;
	
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.CapsLock)){
			if (!checkd) {
				Cursor.visible = true;
				Screen.lockCursor = false;
				checkd = true;
			} else {
				Cursor.visible = false;
				Screen.lockCursor = true;
				checkd = false;
			}
		}
	}
}
	

