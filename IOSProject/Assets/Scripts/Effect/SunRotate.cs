using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour {

	public float rotateAngle = 10f;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.rotation.eulerAngles.z + rotateAngle));
	}
}
