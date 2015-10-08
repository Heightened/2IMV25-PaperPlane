using UnityEngine;
using System.Collections;


public class SceneManagerScript : MonoBehaviour {

	public static int checkpointStatus = 0;

	public static Vector3 planePosition;
	public static Vector3[] positionHistory;

	public static int historySize = 100;
	public static int historyPointer = 0;

	private Vector3 origin = new Vector3(0,0,0);
	private float radius = 50;

	public RotateScript rotateS;

	public static int checkPointSize = 16;

	public Transform checkPointPrefab;
	// Use this for initialization
	void Start () {
		Random.seed = 200;
		positionHistory = new Vector3[historySize];

		for (int i = 0; i < checkPointSize; i++) {
			GameObject g = (GameObject)Instantiate (checkPointPrefab).gameObject;
			RotateScript rotateS = g.GetComponent<RotateScript> ();
			rotateS.checkpointNumber = i;
		}
	}

	bool collideWithSphere(Vector3 rayorigin, Vector3 direction, out float distance){
		distance = 30;
		return true;
	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance = 0f;
		if (collideWithSphere(ray.origin, ray.direction, out distance)) {
			planePosition = ray.GetPoint (distance);
			positionHistory[historyPointer] = planePosition;
			historyPointer++;
			historyPointer %= historySize;
		}
	}
}
