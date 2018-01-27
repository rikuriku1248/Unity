using UnityEngine;
using System.Collections;

public class PatternMovement1 : MonoBehaviour {

	private float[] rootX = new float[300];//経路のx成分を格納する配列
	private float[] rootZ = new float[300];//経路のz成分を格納する配列
	private int maxPathLength = 300;
	int CurrentIndex = 0;
	int pathSize = 0;

	void Start () {
		InitPathArray ();
		//BuildPath (0, 0, 5, 4);
		//BuildPath (5, 4, 0, 0);
		BuildPath (10, 3, 18, 3);
		BuildPath (18, 3, 18, 12);
		BuildPath (18, 12, 10, 12);
		BuildPath (10, 12, 10, 3);
		Normalizepattern ();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(CurrentIndex == pathSize){
				//インデックスの初期化
				CurrentIndex = 0;
			}

			Debug.Log ("[" + rootX[CurrentIndex] + "]" + ", " + "[" + rootZ[CurrentIndex] + "]" + ", pathSize=" + pathSize);
			//this.transform.Rotate (new Vector3 (0, Pattern [CurrentIndex].turnRight, 0));
			//this.transform.Rotate (new Vector3 (0, Pattern [CurrentIndex].turnLeft, 0));
			//this.transform.position (rootX [CurrentIndex], 0, rootZ [CurrentIndex]);
			this.transform.position = new Vector3(rootX [CurrentIndex], 0, rootZ [CurrentIndex]);

			//インデックスのインクリメント
			CurrentIndex++;
		}
	}

	//経路配列の初期化
	private void InitPathArray(){
		for(int i = 0; i < maxPathLength; i++){
			rootX [i] = -1;
			rootZ [i] = -1;
		}
	}

	private void BuildPath(float startX, float startZ, float endX, float endZ){
		float nextX = startX;
		float nextZ = startZ;
		float deltaX = endX - startX;
		float deltaZ = endZ - startZ;
		float stepX, stepZ;
		float fraction;
		int currentStep = 0;

		//経路の初期化
		for(int i = 0; i < maxPathLength; i++){
			if(rootX [i] == -1 && rootZ [i] == -1){
				currentStep = i;
				break;
			}
		}

		//currentStep = 0;

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

	private void Normalizepattern(){
		int i;

		float originX = rootX [0];
		float originZ = rootZ [0];
		//float originX = transform.position.x;
		//float originZ = transform.position.z;

		for(i = 0; i < maxPathLength; i++){
			if(rootX [i] == -1 && rootZ [i] == -1){
				pathSize = i;
				break;
			}
		}

		for(i = 0; i < pathSize; i++){
			rootX [i] = rootX [i] - originX;
			rootZ [i] = rootZ [i] - originZ;
		}
	}
}
