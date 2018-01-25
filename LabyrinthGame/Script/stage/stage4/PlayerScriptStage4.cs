using UnityEngine;
using System.Collections;

public class PlayerScriptStage4 : MonoBehaviour {

	public Material[] material;

	public GameObject WallGreen;
	public GameObject[] WallRed;
	public GameObject[] WallBlue;

	private int i = 0;


	void Start () {
	
	}
	

	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("GreenCapsule")){
			Destroy (collision.gameObject);
			i++;
			this.GetComponent<Renderer> ().material = material [i];
			WallGreen.layer = LayerMask.NameToLayer ("WallGreenLayer");
		}
		if(collision.gameObject.CompareTag("RedCapsule")){
			Destroy (collision.gameObject);
			i++;
			this.GetComponent<Renderer> ().material = material [i];
			for(int j = 0; j < WallRed.Length; j++){
				WallRed[j].layer = LayerMask.NameToLayer ("WallRedLayer");
			}
			WallGreen.layer = LayerMask.NameToLayer ("Default");
		}
		if(collision.gameObject.CompareTag("BlueCapsule")){
			Destroy (collision.gameObject);
			i++;
			this.GetComponent<Renderer> ().material = material [i];
			for (int j = 0; j < WallBlue.Length; j++) {
				WallBlue[j].layer = LayerMask.NameToLayer ("WallBlueLayer");
			}
			for(int j = 0; j < WallRed.Length; j++){
				WallRed[j].layer = LayerMask.NameToLayer ("Default");
			}
		}
	}
}
