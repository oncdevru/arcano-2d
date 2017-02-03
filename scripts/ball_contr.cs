using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball_contr : MonoBehaviour {
	[SerializeField] public GameObject ball_pref;
	public int lives = 11;	
	private int mscr;
	private bool last = false;	
	private GameObject canv, _blovk, _ball, _player, mtext, _cont;


	void Start(){
		canv = GameObject.Find ("Canvas");
		_player = GameObject.Find ("player");
		mtext =  GameObject.Find ("Mtext");
		_cont = GameObject.Find ("controller");
	}

	void Update () {
		_blovk = GameObject.Find ("block(Clone)");
		
		if (canv) {
			if (canv.activeSelf && !last) {
				canv.SetActive (false);
			}
		}

		if(!_ball && lives >0 && _blovk){
			_ball = Instantiate(ball_pref) as GameObject;
			_ball.transform.position = new Vector3(0, -4.0f, -1.0f);
			lives -= 1;
		}else if (!_ball && lives == 0 && !last){
			last = true;	
		} else if( last){
			canv.SetActive(true);
			Cursor.visible = true;
			Screen.lockCursor = false;
			if (_ball) {
				_ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			}
			Text _tet = mtext.GetComponent<Text> ();
			_tet.text = "Вы проиграли";
			Destroy (_player);
		} else if(!_blovk){
			canv.SetActive(true);
			Cursor.visible = true;
			Screen.lockCursor = false;
			if (_ball) {
				_ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			}
			int sc = _cont.GetComponent<Score> ().scr;
			mscr = sc*lives;
			Text _tet = mtext.GetComponent<Text> ();
			_tet.text = "Поздравляем!!! Ваш счет "+  System.Environment.NewLine + mscr;
			Destroy (_player);
		}
	
	}
	void OnGUI() { 		
		GUI.Label(new Rect(10, 10, 150, 100), "Lives: " + lives); 
	}

}
