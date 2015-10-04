using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, Time.realtimeSinceStartup*100);
		float scale = 1.5f+Mathf.Sin(Time.realtimeSinceStartup*4)/4;
		transform.localScale = new Vector3(scale, scale, 0.5f);
	}
}
