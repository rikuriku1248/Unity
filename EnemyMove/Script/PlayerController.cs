using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 pos;
	private Vector3 beforePos;
	public Vector3 nextPos;
	private Vector3 dir;
	public GameController GC;
	public bool _isRendered = false;
	private float startTime;
	private float journeyLength;
	public int speed = 2;
	public bool turnEnd = false;
	private bool move = false;


	Animator animator;

	void Start () {
		pos = transform.position;
		nextPos = pos;
		startTime = Time.time;
		dir = new Vector3(0,0,1);
		animator = GetComponent<Animator> ();
	}


	void Update () {
		if (GC.turnCount % 2 == 0) {
			Move ();
		}
			
		//スムーズに移動させるための処理

		float distCovered = (Time.time - startTime);
		journeyLength = Vector3.Distance (pos, nextPos);
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (pos, nextPos, fracJourney);

		if (transform.position == nextPos) {
			if ((Input.GetKey ("up") == false) && (Input.GetKey ("down") == false) &&
				(Input.GetKey ("right") == false) && (Input.GetKey ("left") == false)) {
				animator.SetBool ("Walk", false);
			}
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
					dir = new Vector3 (1, 0, 1);//Playerの向きを決める
					animator.SetBool ("Walk", true);//Walkアニメーションをtrueに
					move = true;
					turnEnd = true;
				}
			}

			if (Input.GetKey ("left") && Input.GetKey ("up")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, 1);
					startTime = Time.time;
					dir = new Vector3 (-1, 0, 1);
					animator.SetBool ("Walk", true);
					move = true;
					turnEnd = true;
				}
			}

			if (Input.GetKey ("right") && Input.GetKey ("down")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (1, 0, -1);
					startTime = Time.time;
					dir = new Vector3 (1, 0, -1);
					animator.SetBool ("Walk", true);
					move = true;
					turnEnd = true;
				}
			}

			if (Input.GetKey ("left") && Input.GetKey ("down")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, -1);
					startTime = Time.time;
					dir = new Vector3 (-1, 0, -1);
					animator.SetBool ("Walk", true);
					move = true;
					turnEnd = true;
				}
			}
		} else {
			if (Input.GetKey ("right")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (1, 0, 0);
					startTime = Time.time;//フレームの開始時間を取得
					dir = new Vector3 (1, 0, 0);//Playerの向きを決める
					animator.SetBool ("Walk", true);//Walkアニメーションをtrueに
					move = true;
					turnEnd = true;
				}
			}

			if (Input.GetKey ("left")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, 0);
					startTime = Time.time;
					dir = new Vector3 (-1, 0, 0);
					animator.SetBool ("Walk", true);
					move = true;
					turnEnd = true;
				}
			}

			if (Input.GetKey ("up")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (0, 0, 1);
					startTime = Time.time;
					dir = new Vector3 (0, 0, 1);
					animator.SetBool ("Walk", true);
					move = true;
					turnEnd = true;
				}
			}

			if (Input.GetKey ("down")) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (0, 0, -1);
					startTime = Time.time;
					dir = new Vector3 (0, 0, -1);
					animator.SetBool ("Walk", true);
					move = true;
					turnEnd = true;
				}
			}
		}
		//-------------------------------------------------------



		//Playerの位置の更新
		if (transform.position == nextPos && move == true) {
			pos = transform.position;
			//turnEnd = true;
			move = false;
			//キーを離したらWalkアニメーションをfalseに
			if ((Input.GetKey ("up") == false) && (Input.GetKey ("down") == false) &&
			  (Input.GetKey ("right") == false) && (Input.GetKey ("left") == false)) {
				animator.SetBool ("Walk", false);
			}
		}
		//Playerの向きの変更
		Quaternion rotation = Quaternion.LookRotation (dir);
		transform.rotation = rotation;
	}
	void OnWillRenderObject(){
		
		if(Camera.current.name == "EnemyCamera"){
			_isRendered = true;

		}
	}
}