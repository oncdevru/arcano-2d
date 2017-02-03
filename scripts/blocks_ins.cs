using UnityEngine;
using System.Collections;

public class blocks_ins : MonoBehaviour {
	[SerializeField] public GameObject block_prefab;
	private GameObject _block;
	public float offsetX = .8f;
	public float offsetY = -0.4f;
	public float stY = 2.0f;
	public float stX = -2.7f;

	// Use this for initialization
	void Start () {
		for (int j = 0; j < 8; j++) {
			if (j == 6){
				for (int i = 0; i< 6; i++) {
					_block = Instantiate (block_prefab) as GameObject;
					_block.transform.position = new Vector3 (-2.25f + i * offsetX, stY+j*offsetY, -1.0f);					
				}
			}else if(j ==7){
				_block = Instantiate (block_prefab) as GameObject;
				_block.transform.position = new Vector3 (0, stY+j*offsetY, -1.0f);
			}else {
				for (int i = 0; i< 7; i++) {
					_block = Instantiate (block_prefab) as GameObject;
					_block.transform.position = new Vector3 (stX + i * offsetX, stY+j*offsetY, -1.0f);					
				}

			}
		}

	
	}	

}
