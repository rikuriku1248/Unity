using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {

	public Vector3 pos;
	public Vector3 beforePos;
	public Vector3 nextPos;
	public PlayerController PC;
	public GameController GC;
	private float startTime;
	private float journeyLength;
	public int speed = 2;
	public bool move = false;


	void Start () {
		pos = transform.position;
		nextPos = pos;
		startTime = Time.time;
	}
	void Update () {
		if(GC.turnCount % 2 == 0){
			Move ();
		}

		//スムーズに移動させるための処理
		float distCovered = (Time.time - startTime);
		journeyLength = Vector3.Distance(pos, nextPos);
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(pos, nextPos, fracJourney);

		//Playerの位置の更新
		if(transform.position == nextPos && move == true){
			pos = transform.position;
			move = false;
		}
	}

	public void Move(){
		//-------------------------------------------------------
		//方向キー入力で移動

		//斜め移動
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (Input.GetKey ("right") && Input.GetKey ("up")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (1, 0, 1);
					startTime = Time.time;//フレームの開始時間を取得
					move = true;
				}
			}

			if (Input.GetKey ("left") && Input.GetKey ("up")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, 1);
					startTime = Time.time;
					move = true;
				}
			}

			if (Input.GetKey ("right") && Input.GetKey ("down")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (1, 0, -1);
					startTime = Time.time;
					move = true;
				}
			}

			if (Input.GetKey ("left") && Input.GetKey ("down")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, -1);
					startTime = Time.time;
					move = true;
				}
			}
		} else {
			if (Input.GetKey ("right")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (1, 0, 0);
					startTime = Time.time;//フレームの開始時間を取得
					move = true;
				}
			}

			if (Input.GetKey ("left")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, 0);
					startTime = Time.time;
					move = true;
				}
			}

			if (Input.GetKey ("up")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (0, 0, 1);
					startTime = Time.time;
					move = true;
				}
			}

			if (Input.GetKey ("down")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (0, 0, -1);
					startTime = Time.time;
					move = true;
				}
			}
		}
		//-------------------------------------------------------


	}
}