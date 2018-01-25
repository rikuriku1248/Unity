using UnityEngine;
using System.Collections;

public class EnemyMove3 : MonoBehaviour {

	private Vector3 pos;//Enemyの現在位置
	private Vector3 nextPos;//Enemyの目的地（1マス先）
	private Vector3 dir;//進行方向
	private Vector3 dirPlayer;
	private Vector3 dir1;
	private Vector3 dir2;
	private bool move = false;
	public bool moveFlag = false;
	public GameObject Player;
	public PlayerController PC;
	public GameController GC;
	private float startTime;//移動を開始した時間を格納
	private float journeyLength;
	public Transform target;
	private bool moving = true;
	public bool turnEnd = false;
	Animator animator;

	private float[] rootX = new float[300];//経路のx成分を格納する配列
	private float[] rootZ = new float[300];//経路のz成分を格納する配列

	private int j = 0;

	private Vector3 playerPos;//Playerの現在位置

	void Start () {
		Player = GameObject.Find ("Player");
		pos = transform.position;
		playerPos = new Vector3(-1,0,-1);
		nextPos = pos;
		startTime = Time.time;
		dir1 = new Vector3 (0,0,1);
		animator = GetComponent<Animator> ();
	}


	void Update () {
		RaycastHit hit;

		//Playerと自分の位置からPlayerの方向を決める
		dirPlayer = Player.transform.position - this.transform.position;
		dirPlayer = dirPlayer.normalized;

		//Playerがカメラに映るかつPlayerにRayが当たったらmoveFlagをtrueにする
		if (PC._isRendered == true && Physics.Raycast (transform.position, dirPlayer, out hit, 10) == true) {
			if (hit.collider.tag == "Player") {
				moveFlag = true;
			}
		}

		if(moveFlag == true && GC.turnCount % 2 == 1){
			Move ();
		}

	}

	void Move(){
		
		if(Vector3.Distance(playerPos, Player.transform.position) >= 1 && transform.position == nextPos){
			Path_Target (transform.position.x, transform.position.z, PC.nextPos.x, PC.nextPos.z);
			playerPos = Player.transform.position;
			j = 0;
		}
		move = true;

		if (moving == true) {
			if ((rootX [j] == PC.nextPos.x && rootZ [j] == PC.nextPos.z) == false) {
				nextPos = new Vector3 (rootX [j], 0, rootZ [j]);
				startTime = Time.time;
				dir = nextPos - pos;
				dir = dir.normalized;
				dir1 = dir;
				//moving = true;
				moving = false;
				animator.SetBool ("Walk", true);//Walkアニメーションをtrueに
				if ((rootX [j + 1] == Player.transform.position.x && rootZ [j + 1] == Player.transform.position.z) == false) {
					j++;
				}
			}		
		}

		//スムーズに移動させるための処理
		if(move == true){
			float distCovered = (Time.time - startTime);
			journeyLength = Vector3.Distance (pos, nextPos);
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (pos, nextPos, fracJourney);
		}

		//Enemyの位置の更新
		if (transform.position == nextPos && move == true) {
			pos = transform.position;
			turnEnd = true;
			move = false;
			moving = true;
			animator.SetBool ("Walk", false);
		}
		//Enemyの向きの変更
		Quaternion rotation2 = Quaternion.LookRotation (dir1);
		transform.rotation = rotation2;
	}

	//経路探索をする関数(自身の位置のx成分, 自身の位置のz成分, ターゲットの位置のx成分, ターゲットの位置のz成分)
	void Path_Target(float startX, float startZ, float endX, float endZ){
		float nextX = startX;
		float nextZ = startZ;
		float deltaX = endX - startX;
		float deltaZ = endZ - startZ;
		float stepX, stepZ;
		float fraction;
		int currentStep = 0;

		//経路の初期化
		for(currentStep = 0; currentStep < 300; currentStep++){
			rootX [currentStep] = -1;
			rootZ [currentStep] = -1;
		}

		currentStep = 0;

		//各成分の差から移動方向を決定
		if(deltaX < 0){
			stepX = -1;
		}else{
			stepX = 1;
		}
		if(deltaZ < 0){
			stepZ = -1;
		}else{
			stepZ = 1;
		}

		deltaX = Mathf.Abs (deltaX * 2);
		deltaZ = Mathf.Abs (deltaZ * 2);


		if(deltaX > deltaZ){//x軸の方が長い時
			fraction = deltaZ - deltaX / 2;
			while(nextX != endX){
				if(fraction >= 0){
					nextZ += stepZ;
					fraction -= deltaX;
				}
				nextX += stepX;
				fraction += deltaZ;
				rootX [currentStep] = nextX;
				rootZ [currentStep] = nextZ;
				currentStep++;
			}
		}else{//z軸の方が長い時
			fraction = deltaX - deltaZ / 2;
			while(nextZ != endZ){
				if(fraction >= 0){
					nextX += stepX;
					fraction -= deltaZ;
				}
				nextZ += stepZ;
				fraction += deltaX;

				rootX [currentStep] = nextX;
				rootZ [currentStep] = nextZ;
				currentStep++;
			}
		}
	}
}