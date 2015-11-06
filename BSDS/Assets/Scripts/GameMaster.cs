using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public bool SinglePlayer = false;
	public bool MultiPlayer = false;
	public int  BlockCount = 0;
	public bool GameOver = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (BlockCount <= 0) {
			GameOver = true;
			Time.timeScale = 0;
		}
	}
}
