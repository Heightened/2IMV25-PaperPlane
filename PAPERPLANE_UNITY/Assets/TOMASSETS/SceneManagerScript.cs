using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;


public class SceneManagerScript : MonoBehaviour {

	public static int INPUT_DELAY = 10;
	public static int delaypointer = 0;
	public static int[] delayArray;

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

	public static SceneManagerScript reference;
	// Use this for initialization
	void Start () {
		delayArray = new int[10];
		delayArray [0] = 1;
		delayArray [1] = 1;
		delayArray [2] = 1;
		delayArray [3] = 1;
		delayArray [4] = 1;

		delayArray [5] = 10;
		delayArray [6] = 30;
		delayArray [7] = 50;
		delayArray [8] = 100;
		delayArray [9] = 100;
		reference = this;
		positionHistory = new Vector3[historySize];
		
		this.reset ();
	}

	public void reset(){
		INPUT_DELAY = delayArray [delaypointer];
		delaypointer++;
		delaypointer %= delayArray.Length;
		checkpointStatus = 0;
		Random.seed = 200;
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

	public static float startTime = 0;
	public static float totalTime = 0;
	public static void increaseCheckPointCount(){
		checkpointStatus++;
		if (checkpointStatus == 1){
			startTime = Time.realtimeSinceStartup;
		}
		if (checkpointStatus == checkPointSize){
			totalTime = Time.realtimeSinceStartup - startTime;
			writeToFile(INPUT_DELAY + "," + totalTime);
			reference.reset ();
		}

	}

	public static void writeToFile(string text){
		StreamWriter sw = new StreamWriter("tests.txt", true);
		sw.WriteLine(text);
		sw.Close();	
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
