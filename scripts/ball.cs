using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	public float speed = 8.5f;
	public float factor = 30.0f;
	private float plX;
	private bool consist = true;
	private GameObject _player;

	// Use this for initialization
	void Start () {
		_player =  GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		var cvel = GetComponent<Rigidbody2D> ().velocity;
		var tvel = cvel.normalized * speed;
		GetComponent<Rigidbody2D> ().velocity = Vector2.Lerp(cvel, tvel, Time.deltaTime * factor);
		if (Input.GetMouseButtonDown (0) && consist) { 
			GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 9000.0f * Time.deltaTime);
			consist = false;
		}
		if(consist) {
			plX = _player.transform.position.x;
			transform.position = new Vector3(plX, -4.0f, -1.0f);
		}
	}
}
