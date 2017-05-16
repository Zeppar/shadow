using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate : MonoBehaviour {

	public float rotateAngle = 20f;
	public float smoothing = 1f;
	bool isRight = true;
	// Use this for initialization
	void Start () {
		
	}

	//做匀速旋转不要使用lerp！
	// Update is called once per frame

	void Update () {
//		print ("transform.rotation.eulerAngles.z : " + transform.rotation.eulerAngles.z);
//		print ("Quaternion.Euler(new Vector3(0, 0, -1 * rotateAngle)).z : " + Quaternion.Euler(new Vector3(0, 0, -1 * rotateAngle)).eulerAngles.z);

//		if (transform.rotation.eulerAngles.z <= (360 - Quaternion.Euler(new Vector3(0, 0, -1 * rotateAngle)).eulerAngles.z)) {
//			transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 0.5f));
//			isRight = true;
//		} else if (transform.rotation.eulerAngles.z >= Quaternion.Euler(new Vector3(0, 0, 1 * rotateAngle)).eulerAngles.z) {
//			transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 0.5f));
//			isRight = false;
//		} else {
//			if (isRight) {
//				transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 0.5f));
//			} else {
//				transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 0.5f));
//			}
//		}

		if (Mathf.Abs(transform.rotation.eulerAngles.z) < 0.01f) {
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 0.05f));
			isRight = true;
		} else if (Mathf.Abs(transform.rotation.eulerAngles.z - 30f) < 0.01f) {
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 0.05f));
			isRight = false;
		} else {
			if (isRight) {
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 0.05f));
			} else {
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 0.05f));
			}
		}
	}
}
