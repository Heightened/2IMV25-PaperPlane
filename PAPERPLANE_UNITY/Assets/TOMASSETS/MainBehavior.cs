using UnityEngine;
using System.Collections;


public class MainBehavior : MonoBehaviour {

	bool chase = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (chase) {
			Vector3 diff = SceneManagerScript.planePosition - transform.position;
			transform.position += diff / 5;
		} else {
			int delayedPos = SceneManagerScript.historyPointer - SceneManagerScript.INPUT_DELAY;
			if (delayedPos < 0) delayedPos += SceneManagerScript.historySize;
			transform.position = SceneManagerScript.positionHistory[delayedPos];
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "CHECKPOINT" )
		{
			RotateScript rotateS = col.gameObject.GetComponent<RotateScript> ();
			if (rotateS.checkpointNumber == SceneManagerScript.checkpointStatus){
				Destroy(col.gameObject);
				SceneManagerScript.increaseCheckPointCount();
			}
		}
	}
}
