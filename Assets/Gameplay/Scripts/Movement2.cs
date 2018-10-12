using System.Collections;
using UnityEngine;

public class Movement2 : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float walkTime;
	[SerializeField] private float waitTime;

	[SerializeField] private bool isWalking;

	[SerializeField] private Collider2D board;

	private Rigidbody2D myRigidbody;

	private float walkCounter;
	private float waitCounter;

	private int walkDirection;

	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private bool hasBoard;

	void Start() {
		myRigidbody = GetComponent<Rigidbody2D> ();

		walkCounter = waitTime;
		waitCounter = waitTime;

		ChooseDirection ();

		if (board != null) {
			minWalkPoint = board.bounds.min;
			maxWalkPoint = board.bounds.max;
			hasBoard = true;

			Debug.Log (minWalkPoint);
			Debug.Log (maxWalkPoint);
		}
	}

	void Update() {
		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (walkDirection) {
			case 0:
				myRigidbody.velocity = new Vector2 (0, moveSpeed);
				if (hasBoard && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 1:
				myRigidbody.velocity = new Vector2 (moveSpeed, 0);
				if (hasBoard && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 2:
				myRigidbody.velocity = new Vector2 (0, -moveSpeed);
				if (hasBoard && transform.position.y < minWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 3:
				myRigidbody.velocity = new Vector2 (-moveSpeed, 0);
				if (hasBoard && transform.position.x < minWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			}

			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}

		} else {
			waitCounter -= Time.deltaTime;

			myRigidbody.velocity = Vector2.zero;

			if (waitCounter < 0)
				ChooseDirection ();

		}
			
	}

	private void StopWalking() {
		isWalking = false;
		waitCounter = waitTime;
	}

	public void ChooseDirection() {
		walkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}
}