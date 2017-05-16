using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Player player;
	public float delta;

	void Start() {
		delta = 6f;
	}

	void LateUpdate() {
		Vector3 pos = transform.position;
		pos.x = player.transform.position.x + delta;
		transform.position = pos;
	}

}
