using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//public GameObject GoalText;
	public GameObject ClearPanel;

	public Text TimeText;
	public GameObject TimeTextObj;
	public Text ClearTimeText;

	public ClearScript clearScript;
	public Controller controller;


	float time;//時間を記録する変数

	int min;
	int sec;
	float dec;
	string minText;
	string secText;
	string decText;

	void Start () {
		

		//時間の初期化
		time = 0;

		Time.timeScale = 1;
	}

	void Update () {

		//ゴールした時isGoalはtrue
		if (clearScript.isClear == true) {
			GameClear ();
		} else {
			CountUp ();
		}


	}

	//タイムを表示
	void CountUp(){
		time += Time.deltaTime;
		min = (int)time / 60;
		sec = (int)time % 60;
		dec = (time - (int)time) * 100;
		minText = min.ToString ("D2");
		secText = sec.ToString ("D2");
		decText = dec.ToString ("f0");
		TimeText.text = "Time : " + minText + ":" + secText + "." + decText;
	}

	//ゲームクリア時の処理
	void GameClear(){
		ClearPanel.SetActive (true);
		//停止
		Time.timeScale = 0;
		//fieldの移動を不可にする
		controller.MoveField = false;
		//TimeTextを非表示
		TimeTextObj.SetActive(false);
		//ClearTimeTextの更新
		ClearTimeText.text = "Time : " + minText + ":" + secText + "." + decText;
	}
		
}
