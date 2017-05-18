using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

	public GameObject[] road;
	public GameObject currentRoad;
	public GameObject lastRoad;
	public GameObject mapLayer;
	float remainLength = 15f;
	public Player player;
	// Use this for initialization
	void Start () {
//		remainLength = currentRoad.GetComponent<Renderer> ().bounds.size.x * 0.5f;
//		print("road.GetComponent<Renderer> ().bounds.size.x : " + road.GetComponent<Renderer> ().bounds.size.x);
//		print("road.GetComponent<Renderer> ().bounds.size.y : " + road.GetComponent<Renderer> ().bounds.size.y);
//		GameObject r = Instantiate (road [1]) as GameObject;
//		r.transform.SetParent (mapLayer.transform);
//		r.transform.localPosition = currentRoad.transform.position + new Vector3(road[1].GetComponent<Renderer> ().bounds.size.x , 0, 0);
//		currentRoad = r;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > currentRoad.transform.position.x + currentRoad.GetComponent<Renderer> ().bounds.size.x * 0.5f - remainLength) {
			GameObject r = Instantiate (road [1]) as GameObject;
			r.transform.SetParent (mapLayer.transform);
			r.transform.localPosition = currentRoad.transform.position + new Vector3 (road [1].GetComponent<Renderer> ().bounds.size.x, 0, 0);
			lastRoad = currentRoad;
			currentRoad = r;
		} else if (player.transform.position.x > lastRoad.transform.position.x + currentRoad.GetComponent<Renderer> ().bounds.size.x * 0.5f + remainLength) {
			Destroy (lastRoad);
			lastRoad = currentRoad;
		}
	}
}
