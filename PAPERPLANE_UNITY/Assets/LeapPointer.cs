using UnityEngine;
using System.Collections;

public class LeapPointer : MonoBehaviour {
    public static Ray ray;

	void Update () {
        HandModel hand = gameObject.GetComponentInChildren<HandModel>();
        //HandModel hand = gameObject.GetComponent<HandModel>();
        print(hand);
        ray = hand.fingers[1].GetRay();
	}
}