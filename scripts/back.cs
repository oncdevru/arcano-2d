using UnityEngine;
using System.Collections;

public class back : MonoBehaviour {

	public GameObject cam;

	public void back_func() {
		cam.transform.position =new Vector3(0,0,-10);
	}
}
