using UnityEngine;
using System.Collections;

public class block_die : MonoBehaviour {

	[SerializeField] private GameObject bonus_pr;
	public GameObject contr;
	private int[] arry = new int[5];
	public AudioClip _exp;

	// Use this for initialization
	void Start () {
		contr = GameObject.Find("controller");
	}

	void OnCollisionEnter2D(Collision2D otherObj) {
		int ver = Mathf.CeilToInt(Random.Range (0, arry.Length));
		if (otherObj.gameObject.tag == "ball") {	
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (_exp, 0.8f);
			contr.GetComponent<Score>().scr += 10;
			Destroy(gameObject,.2f);
			if (ver==3){
				StartCoroutine (block_d());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D otherObj) {
		int ver = Mathf.CeilToInt(Random.Range (0, arry.Length));
		if (otherObj.gameObject.tag == "ball") {
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (_exp, 0.8f);
			contr.GetComponent<Score>().scr += 10;
			Destroy(gameObject,.2f);
			if (ver==3){
				StartCoroutine (block_d());
			}
		}
	}

	private IEnumerator block_d(){		
		GameObject _bonusTmp = Instantiate (bonus_pr) as GameObject;
		Vector3 tmp = transform.position;
		_bonusTmp.transform.position = tmp;
		yield return new WaitForSeconds (3);
		Destroy (_bonusTmp);
	}
}
