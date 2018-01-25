using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public PlayerController PC;
	public EnemyMove3 EM;
	public int turnCount = 0; //偶数ターン:playerのターン, 奇数ターン:enemyのターン

	void Start () {
	
	}
	

	void Update () {
		//playerのキー入力が検出されるとturnEndがtrueになる
		if(PC.turnEnd == true){
			turnCount++; //ターンを進める
			Debug.Log (turnCount);
			Debug.Log ("player");
			PC.turnEnd = false; //turnEndをfalseに戻す
		} 
		//enemyがnextPosにたどり着くとturnEndとなる
		if(EM.turnEnd == true){
			turnCount++; //ターンを進める
			Debug.Log (turnCount);
			Debug.Log ("enemy");
			EM.turnEnd = false; //turnEndをfalseに戻す
		}
	}
}
