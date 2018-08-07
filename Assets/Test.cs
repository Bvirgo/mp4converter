using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {	
		StartCoroutine("doIt");
	}

	IEnumerator doIt()
	{
		Debug.Log(Application.persistentDataPath);
		bool done = false;
		Mp4Converter.Convert("Crusade Runner.wav", "VideoBackground.mov", "out.mp4", ref done);

		while(!done)
			yield return null;

		Debug.Log("DONE!!!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
