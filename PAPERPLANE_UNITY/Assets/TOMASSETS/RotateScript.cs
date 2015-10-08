using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	float radius = 30;

	public int checkpointNumber = 0;
	// Use this for initialization
	void Start () {
		float incl = Random.Range(-Mathf.PI/4, Mathf.PI/4);
		float azi = Random.Range(-Mathf.PI/4, Mathf.PI/4);
		Vector3 pos = new Vector3 ();
		pos.x = radius * Mathf.Sin (azi) * Mathf.Cos (incl);
		pos.y = radius * Mathf.Sin (azi) * Mathf.Sin (incl);
		pos.z = radius * Mathf.Cos(azi);
		transform.position = pos;
	}
	
	// Update is called once per frame
	float targetScale = 0;
	float scaleModifier = 0;
	void Update () {
		int diff = checkpointNumber - SceneManagerScript.checkpointStatus;
		if (diff > 2) {
			diff = 3;
		}
		Color c = new Color (1, (diff)/3f, (diff)/3f, 1);

		GetComponent<Renderer> ().material.color = c;

		targetScale = (3-diff);

		scaleModifier += (targetScale - scaleModifier)/5;

		transform.rotation = Quaternion.Euler(0.0f, Time.realtimeSinceStartup*100, Time.realtimeSinceStartup*100);
		float scale = 2+scaleModifier+Mathf.Sin(Time.realtimeSinceStartup*4)/4;
		transform.localScale = new Vector3(scale, scale, scale);
	}
}
