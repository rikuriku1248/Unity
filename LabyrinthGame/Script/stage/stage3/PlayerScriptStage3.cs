using UnityEngine;
using System.Collections;

public class PlayerScriptStage3 : MonoBehaviour {


	public Material[] material;

	public GameObject WallBlue;

	private int i = 0;

	void Start () {
	
	}
	

	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("BlueCapsule")){
			Destroy (collision.gameObject);
			i++;
			this.GetComponent<Renderer> ().material = material [i];
			WallBlue.layer = LayerMask.NameToLayer ("WallBlueLayer");
		}
	}
}
