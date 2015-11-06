using UnityEngine;
using System.Collections;

public class PixelPerfect : MonoBehaviour {

	public float TexSize = 100f;
	float unitsPerPixel;

	// Use this for initialization
	void Start () {
		unitsPerPixel = 1.0f / TexSize;

		Camera.main.orthographicSize = (Screen.height / 2f) * unitsPerPixel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
