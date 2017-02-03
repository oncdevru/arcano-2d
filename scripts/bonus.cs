using UnityEngine;
using System.Collections;

public class bonus : MonoBehaviour {
	
	[SerializeField] private GameObject laser;
	[SerializeField] private GameObject fire;
	private GameObject _laser;
	private GameObject contr;
	private GameObject spot;
	private GameObject n_ballOne;
	private GameObject _player;
	private int[] bns = new int[4];
	private string _bns;
	public float speed = 8.5f;
	public float factor = 30.0f;

	void Start(){
		contr = GameObject.Find("controller"); 

		_player = GameObject.Find("player"); 
		int ver = Mathf.CeilToInt(Random.Range (0, bns.Length));
		switch (ver) {
		case 1:
			_bns = "scale";
			break;
		case 2:
			_bns = "clone";
			break;
		case 3:
			_bns = "laser";
			break;
		default:
			_bns = "score";
			break;
		}
		
	}

	void Update(){
		if (_laser) {
			if (_player) {
				_laser.transform.position = new Vector3 (_player.transform.position.x, _player.transform.position.y, -2F);
			}
			if(Input.GetMouseButtonDown(0)){
				StartCoroutine (fire_c());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D trig){		
		if(trig.gameObject.name == "player"){
			switch (_bns) {
			case "scale":
				StartCoroutine (Scaller(trig.gameObject));
				break;
			case "clone":
				StartCoroutine (ball_clone());
				break;
			case "laser": 
				StartCoroutine (laser_c());
				break;
			case "score": 				
				contr.GetComponent<Score> ().scr += 200;
				break;				
			}			
		}
	}

	private IEnumerator Scaller(GameObject objj){
		objj.transform.localScale = new Vector3 (2f, 1f, 1f);
		yield return new WaitForSeconds(8);
		if (objj) {
			objj.transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}

	private IEnumerator ball_clone(){
		if (!n_ballOne) {
			spot = GameObject.FindWithTag ("ball");
			n_ballOne = Instantiate (spot) as GameObject;
			n_ballOne.transform.position = spot.transform.position;

			yield return new WaitForSeconds(5);
			Destroy (n_ballOne);
		}
	}
	private IEnumerator laser_c(){
		if(!_laser){
			_laser = Instantiate (laser) as GameObject;
		}

		yield return new WaitForSeconds(3);
		Destroy (_laser);
	}

	private IEnumerator fire_c(){
		GameObject _firetmp = Instantiate (fire) as GameObject;
		var cvel = _firetmp.GetComponent<Rigidbody2D> ().velocity;
		var tvel = cvel.normalized * speed;
		_firetmp.transform.position = new Vector3 (_laser.transform.position.x, _laser.transform.position.y + 1.0F, -1.0F);
		_firetmp.GetComponent<Rigidbody2D> ().velocity = Vector2.Lerp(cvel, tvel, Time.deltaTime * factor);
		_firetmp.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 9000.0f * Time.deltaTime);
		AudioClip fire_t = contr.GetComponent<audioController> ().fire_au;
		contr.GetComponent<AudioSource> ().PlayOneShot (fire_t, 0.12f);

		yield return new WaitForSeconds(3);
		Destroy (_firetmp);
	}
}