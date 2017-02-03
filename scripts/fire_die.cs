using UnityEngine;
using System.Collections;

public class fire_die : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.name == "block(Clone)") {
			Destroy (this.gameObject);
		}
	}
}
