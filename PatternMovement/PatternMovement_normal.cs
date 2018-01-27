using UnityEngine;
using System.Collections;

public class PatternMovement_normal : MonoBehaviour {

	ControllData[] Pattern;

	int CurrentIndex = 0;

	//制御命令構造体
	struct ControllData{
		public float turnRight;
		public float turnLeft;
		public float stepForward;
		public float stepBackward;
	}

	void Start () {
		Pattern = new ControllData[4];
		for(int i = 0; i < Pattern.Length; i++){
			Pattern[0] = new ControllData();
		}
		InitPattern ();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(CurrentIndex == 4){
				//インデックスの初期化
				CurrentIndex = 0;
			}

			this.transform.Rotate (new Vector3 (0, Pattern [CurrentIndex].turnRight, 0));
			this.transform.Rotate (new Vector3 (0, Pattern [CurrentIndex].turnLeft, 0));
			this.transform.Translate (0, 0, Pattern [CurrentIndex].stepForward);
			this.transform.Translate (0, 0, Pattern [CurrentIndex].stepBackward);

			//インデックスのインクリメント
			CurrentIndex++;
		}
	}
		

	//パターンの初期化
	public void InitPattern(){
		Pattern [0].turnRight = 0;
		Pattern [0].turnLeft = 0;
		Pattern [0].stepForward = 1;
		Pattern [0].stepBackward = 0;

		Pattern [1].turnRight = 90;
		Pattern [1].turnLeft = 0;
		Pattern [1].stepForward = 0;
		Pattern [1].stepBackward = 0;

		Pattern [2].turnRight = 0;
		Pattern [2].turnLeft = 0;
		Pattern [2].stepForward = 1;
		Pattern [2].stepBackward = 0;

		Pattern [3].turnRight = 90;
		Pattern [3].turnLeft = 0;
		Pattern [3].stepForward = 0;
		Pattern [3].stepBackward = 0;

	}
}
