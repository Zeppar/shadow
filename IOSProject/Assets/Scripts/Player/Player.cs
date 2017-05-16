using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
	forward,
	backward
}


public class Player : MonoBehaviour {

	Animator playerAnim;
	public float moveParam = 1.5f;
	public float blinkParam = 2.0f;
	Rigidbody2D rb;
	public float jumpParam = 3f;
	bool isGround = true;
	public int jumpTimes = 2;
	Direction jumpDir = Direction.forward;
	bool isForwardBlink = false;
	bool isBackwardBlink = false;
	public float blinkForwardTime = -1f;
	public float blinkBackwardTime = -1f;

	void Start() {
		playerAnim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		//用受力改变速度 速度会越来越快
//		rb.AddForce (Vector2.right * moveParam);
		if (isGround) {
			if (!isForwardBlink && !isBackwardBlink)
				rb.velocity = new Vector2 (moveParam, rb.velocity.y);
			else {
				if (blinkForwardTime > 0) {
					blinkForwardTime -= Time.deltaTime;
					rb.velocity = new Vector2 (blinkParam, rb.velocity.y);
				} else {
					blinkForwardTime = -1;
					isForwardBlink = false;
				}
				playerAnim.SetFloat ("BlinkForwardTime", blinkForwardTime);

				if (blinkBackwardTime > 0) {
					blinkBackwardTime -= Time.deltaTime;
					rb.velocity = new Vector2 (-0.6f * blinkParam, rb.velocity.y);
				} else {
					blinkBackwardTime = -1;
					isBackwardBlink = false;
				}
				playerAnim.SetFloat ("BlinkBackwardTime", blinkBackwardTime);

			}
		} else {
			if (jumpDir == Direction.forward) {
				rb.velocity = new Vector2 (moveParam * 1.2f, rb.velocity.y);
			} else {
				rb.velocity = new Vector2 (-moveParam * 0.8f, rb.velocity.y);
			}
		}
		playerAnim.SetFloat("VerticalSpeed", rb.velocity.y);
//		print ("rb.velocity.y : " + rb.velocity.y);

	}

	public void DoBlink(Direction dir) {
		if (isForwardBlink || isBackwardBlink)
			return;
		if (dir == Direction.forward) {
			blinkForwardTime = 0.4f;
			isForwardBlink = true;
			playerAnim.SetFloat ("BlinkForwardTime", blinkForwardTime);
			rb.velocity = new Vector2 (blinkParam, rb.velocity.y);
		} else {
			blinkBackwardTime = 0.4f;
			isBackwardBlink = true;
			playerAnim.SetFloat ("BlinkBackwardTime", blinkBackwardTime);
			rb.velocity = new Vector2 (-0.6f * blinkParam, rb.velocity.y);
		}
	}

	public void DoJump(Direction dir) {
		if (jumpTimes <= 0)
			return;
		jumpTimes--;
		if (dir == Direction.forward) {
			print ("forward");
			jumpDir = Direction.forward;
//			rb.AddForce (new Vector2 (2.5f, 2.5f) * jumpParam);
			rb.velocity = new Vector2(rb.velocity.x + 5, 5f);
		} else {
			print ("backward");
			jumpDir = Direction.backward;
//			rb.AddForce (new Vector2 (-2.5f, 2.5f) * jumpParam);
			rb.velocity = new Vector2(rb.velocity.x - 5, 5f);
		}
	}

	public void DoSlide() {
	
	}

	public void DoDefence() {
	
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.tag == "Ground") {
			isGround = true;
			playerAnim.SetBool ("isGround", isGround);
			jumpTimes = 2;
		}
	}

	public void OnCollisionExit2D(Collision2D col) {
		if (col.collider.tag == "Ground") {
			isGround = false;
			playerAnim.SetBool ("isGround", isGround);
		}
	}
}
