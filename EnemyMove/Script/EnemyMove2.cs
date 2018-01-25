using UnityEngine;
using System.Collections;

public class EnemyMove2 : MonoBehaviour {

	private Vector3 pos;//Enemyの現在位置
	private Vector3 nextPos;//Enemyの目的地（1マス先）
	private Vector3 dir;//進行方向
	private Vector3 dir1;//進行方向
	private Vector3 dir2;//進行方向
	private float angleDir;
	public bool moveFlag = false;
	public GameObject Player;
	public PlayerController PC;
	private float startTime;//移動を開始した時間を格納
	private float journeyLength;
	//public int speed = 2;
	public Transform target;
	Animator animator;

	void Start () {
		Player = GameObject.Find ("Player");
		pos = transform.position;
		//nextPos = new Vector3(1,0,0);
		nextPos = pos;
		startTime = Time.time;
		dir = new Vector3(0,0,0);
		animator = GetComponent<Animator> ();

	}


	void Update () {
		RaycastHit hit;

		//Playerと自分の位置からPlayerの方向を決める
		dir1 = Player.transform.position - this.transform.position;
		dir2 = dir1.normalized;

		if (PC._isRendered == true && Physics.Raycast (transform.position, dir2, out hit, 5) == true) {
			Debug.Log ("WWWWWW");
			if (hit.collider.tag == "Player") {
				moveFlag = true;
			}
		}
		if (moveFlag == true) {
			Move ();
		}
		

	}

	void Move(){
		//------------------------------------------------------
		//Playerとの座標の差から移動方向を決定
		if(Mathf.Abs((target.transform.position.x)-(transform.position.x)) >= 2){
			if ((target.transform.position.x)-(transform.position.x) > 0) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (1, 0, 0);//右に移動
					startTime = Time.time;//フレームの開始時間を取得
					dir = new Vector3(1,0,0);//Playerの向きを決める
					animator.SetBool ("Walk", true);//Walkアニメーションをtrueに
				}
			}

			if((target.transform.position.x)-(transform.position.x) < 0){
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (-1, 0, 0);//左に移動
					startTime = Time.time;
					dir = new Vector3(-1,0,0);
					animator.SetBool ("Walk", true);
				}
			}
		}
		if(Mathf.Abs((target.transform.position.z)-(transform.position.z)) >= 2 ){
			if ((target.transform.position.z)-(transform.position.z) > 0) {
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (0, 0, 1);//上に移動
					startTime = Time.time;
					dir = new Vector3(0,0,1);
					animator.SetBool ("Walk", true);
				}
			}

			if((target.transform.position.z)-(transform.position.z) < 0){
				if (transform.position == nextPos) {
					nextPos = pos + new Vector3 (0, 0, -1);//下に移動
					startTime = Time.time;
					dir = new Vector3(0,0,-1);
					animator.SetBool ("Walk", true);
				}
			}
		}

		if (Mathf.Abs ((target.transform.position.x) - (transform.position.x)) == 1 && Mathf.Abs ((target.transform.position.z) - (transform.position.z)) == 1) {
			animator.SetBool ("Walk", false);
		}
		//-------------------------------------------------------

		//スムーズに移動させるための処理
		float distCovered = (Time.time - startTime);
		journeyLength = Vector3.Distance(pos, nextPos);
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(pos, nextPos, fracJourney);

		//Enemyの位置の更新
		if(transform.position == nextPos){
			pos = transform.position;
		}
		//Enemyの向きの変更
		Quaternion rotation = Quaternion.LookRotation (dir);//進行方向に向きを設定
		transform.rotation = rotation;
	}
}