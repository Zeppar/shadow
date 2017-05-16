using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

	public float moveSpeed = 1f;
	bool isRight = true;
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.x <= -270f) {
			transform.localPosition = new Vector3 (transform.localPosition.x + moveSpeed, transform.localPosition.y, transform.localPosition.z);
			isRight = true;
		} else if (transform.localPosition.x >= 300f) {
			transform.localPosition = new Vector3 (transform.localPosition.x - moveSpeed, transform.localPosition.y, transform.localPosition.z);
			isRight = false;
		} else {
			if (isRight) {
				transform.localPosition = new Vector3 (transform.localPosition.x + moveSpeed, transform.localPosition.y, transform.localPosition.z);
			} else {
				transform.localPosition = new Vector3 (transform.localPosition.x - moveSpeed, transform.localPosition.y, transform.localPosition.z);
			}
		}
	}
}
