using UnityEngine;
using System.Collections;


public class MainBehavior : MonoBehaviour {

	bool chase = false;
	private int delay = 90;
	// Use this for initialization
	void Start () {
		if (delay > SceneManagerScript.historySize-1) {
			//crap
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (chase) {
			Vector3 diff = SceneManagerScript.planePosition - transform.position;
			transform.position += diff / 5;
		} else {
			int delayedPos = SceneManagerScript.historyPointer - delay;
			if (delayedPos < 0) delayedPos += SceneManagerScript.historySize;
			transform.position = SceneManagerScript.positionHistory[delayedPos];
		}
	}
}
