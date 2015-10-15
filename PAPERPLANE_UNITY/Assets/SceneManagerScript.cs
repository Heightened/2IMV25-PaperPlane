using UnityEngine;
using System.Collections;
using Leap;


public class SceneManagerScript : MonoBehaviour {

	public static Vector3 planePosition;
	public static Vector3[] positionHistory;

	public static int historySize = 100;
	public static int historyPointer = 0;

	private Plane tracePlane = new Plane(new Vector3(0,0,-1), new Vector3(0,0,0));
	// Use this for initialization
	void Start () {
		positionHistory = new Vector3[historySize];
	}
	
	// Update is called once per frame
	void Update () {
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = LeapRay.pointer;
        //HandModel hand = GetComponent<HandModel>();
        //Ray ray = new Ray(hand.GetPalmPosition(), hand.GetPalmDirection());
        //Ray ray = hand.fingers[1].GetRay();
        Ray ray = LeapPointer.ray;

		float distance = 0f;
		if (tracePlane.Raycast (ray, out distance)) {
			planePosition = ray.GetPoint (distance);
			positionHistory[historyPointer] = planePosition;
			historyPointer++;
			historyPointer %= historySize;
		}
	}
}
