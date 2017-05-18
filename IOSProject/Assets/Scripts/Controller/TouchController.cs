using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TouchType {
	LeftAttack,
	RightAttack
}

public class TouchController : MonoBehaviour {

	public Player player;
	TouchType type = TouchType.LeftAttack;
	Touch touch;
	float middleX = 0;
	Vector2 startPos;
	Vector2 endPos;
	Vector2 deltaPos;
	Vector2 right;
	float angle;

	void Start() {
		middleX = Screen.height * 0.5f;
		right = transform.right;
	}

	void Update() {
//		print ("Screen.height : " + Screen.height + " Screen.widht : " + Screen.width);
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				if (type == TouchType.LeftAttack) {
					if (touch.position.x <= middleX) {
						print ("Left 左侧操作区");
					} else {
						print ("Left 右侧操作区");
					}
				} else {
					if (touch.position.x <= middleX) {
						print ("Right 左侧操作区");
					} else {
						print ("Right 右侧操作区");
					}
				}
				startPos = touch.position;
			} else if (touch.phase == TouchPhase.Moved) {
				
			} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
				if ((type == TouchType.LeftAttack && touch.position.x <= middleX) || (type == TouchType.RightAttack && touch.position.x >= middleX)) {
					endPos = touch.position;
					deltaPos = endPos - startPos;
					angle = Vector2.Angle (right, deltaPos);
					print ("angle : " + angle);
					print ("delta : " + deltaPos.x + " " + deltaPos.y);
					if (angle >= 0 && angle < 15f) {
						print ("前突");
						player.DoBlink (Direction.forward);
					} else if (angle >= 15f && angle < 90f) {
						if (deltaPos.y >= 0) {
							print ("前跳");
							player.DoJump (Direction.forward);
						} else {
							print ("前铲");
						}
					} else if (angle >= 90f && angle < 165f) {
						if (deltaPos.y >= 0) {
							print ("后跳");
							player.DoJump (Direction.backward);
						} else {
							print ("后蹲防");
						}
					} else if (angle >= 165f && angle <= 180) {
						print ("后突");
						player.DoBlink (Direction.backward);
					}
				}
			}
		}

		//test mode
		if (Input.GetKeyDown (KeyCode.E)) {
			player.DoJump (Direction.forward);
		} else if (Input.GetKeyDown (KeyCode.Q)) {
			player.DoJump (Direction.backward);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			player.DoBlink (Direction.forward);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			player.DoBlink (Direction.backward);
		} 

//		print ("X : " + player.transform.localPosition.x);
	}

	public void ChangeTouchType() {
		if (type == TouchType.LeftAttack) {
			print ("change to right");
			type = TouchType.RightAttack;		
		} else {
			print ("change to left");
			type = TouchType.LeftAttack;
		}
	}
}
