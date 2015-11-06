using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerate : MonoBehaviour {

    public List<GameObject> Blocks;
	int blockCount = 0;

	public int Height = 4;
	public int HOffset = 1;

	void Awake() {


	}

	// Use this for initialization
	void Start () {

        for (int y = 0; y < Height; y++)
        {
			for (int x = 0; x < (Screen.width / 64); x++)
            {
                int rand = Random.Range(0, 3);
                GameObject go = Blocks[rand];
				float halfScreen = Screen.height / 2.0f;
				float halfHeight = (float)Height / 2.0f;
				Vector3 pos = new Vector3 (32 + (64 * x), halfScreen + (halfHeight * 32f) - (32 * y), 10);
				Vector3 spos = Camera.main.ScreenToWorldPoint(pos);
                Instantiate(go, new Vector3(spos.x, spos.y,0), Quaternion.identity);
				blockCount++;
            }
        }
        
		GameMaster gm = GetComponent<GameMaster> ();
		gm.BlockCount = blockCount;
	}

    // Update is called once per frame
    void Update()
    {
	
	}

	void OnGUI()
	{ 
		GUI.Label(new Rect(0, 100,Screen.width,Screen.height), blockCount.ToString());
	}
}
