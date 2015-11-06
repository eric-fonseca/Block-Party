using UnityEngine;
using System.Collections;

public class SceneSelection : MonoBehaviour {

	public void LoadSinglePlayer()
	{
		Application.LoadLevel ("Level01");
	}

	public void LoadMultiPlayer()
	{
		Application.LoadLevel ("Level00");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
