using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed = 10;
	// Use this for initialization
	void Start () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		if (body) {
			body.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float posY = transform.position.y;
		float posZ = transform.position.z;

		float dx = Input.GetAxis ("Horizontal");
		float dxx = Input.GetAxis ("Mouse X");
		transform.Translate (dx*Time.deltaTime*speed, 0, 0);
		transform.Translate (dxx*Time.deltaTime*speed, 0, 0);
		if (transform.position.x <= -4.55f) {
			transform.position = new Vector3 (-4.55f, posY, posZ);
		} else if (transform.position.x >= 4.55f) {
			transform.position = new Vector3 (4.55f, posY, posZ);
		}
	}
}
