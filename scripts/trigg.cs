using UnityEngine;
using System.Collections;

public class trigg : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){		
		if (col.gameObject.tag == "ball") {
			
			Destroy(col.gameObject, 0.1f);	
		}
	}
}
