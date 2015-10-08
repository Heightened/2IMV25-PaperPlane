using UnityEngine;
using System.Collections;
using Leap;

public class LeapRay : HandController {
    public static Ray pointer = Camera.main.ScreenPointToRay(Input.mousePosition);
    Hand trackedHand = null;

    public void onCreateHand(Hand h) {
        if (trackedHand == null) {
            trackedHand = h;
            print("created hand");
        }
    }

    public void onDestroyHand(Hand h) {
        if (trackedHand.Id == h.Id) {
            trackedHand = null;
        }
    }

    override protected void Update() {
        base.Update();
        if (trackedHand != null) {
            pointer = new Ray(trackedHand.PalmPosition.ToUnity(false), trackedHand.Direction.ToUnity(false));
        }
    }
}