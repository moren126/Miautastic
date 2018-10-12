using System.Collections;
using UnityEngine;
using Zenject;

public class Movement : MonoBehaviour {

	[SerializeField] private float maxSpeed;
	[SerializeField] private float maxForce;
	[SerializeField] private float walkTime;
	//[SerializeField] private float waitTime;

	[SerializeField] private bool isChangingDirection;

	[SerializeField] private Collider2D board;

	private Rigidbody2D myRigidbody;

	private float walkCounter;
	//private float waitCounter = 1;
	private Vector2 wanderVel;
	//private Vector2 awoidWallsVel;
	private float shitTime;
	private float shitCounter;

	private int walkDirection;

	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private bool hasBoard;

	private GameplayManager gameplayManager;
	//private ShitHolder shitHolder;

	[Inject]
	private void Construct (GameplayManager _gameplayManager) {
		gameplayManager = _gameplayManager;
		//shitHolder = _shitHolder;
	}

	void Start() {
		myRigidbody = GetComponent<Rigidbody2D> ();

		walkCounter = walkTime;

		shitTime = Random.value * 20f;
		shitCounter = shitTime;

		StartWalking ();

		if (board != null) {
			minWalkPoint = board.bounds.min;
			maxWalkPoint = board.bounds.max;
			hasBoard = true;

			//Debug.Log (minWalkPoint);
			//Debug.Log (maxWalkPoint);
		}
	}

	private Vector2 Wander() {
		if (isChangingDirection) {
			walkCounter -= Time.deltaTime;

			if (walkCounter < 0) {
				StopWalking ();
			}
		} else {
			wanderVel = Seek (GetTargetPosition ());
			StartWalking ();
		}

		return wanderVel;
	}

	private Vector2 AwoidWalls() {

		Vector2 awoidWallsVel = new Vector2 (0, 0);
		bool nearWall = false;

		if (hasBoard && transform.position.y > maxWalkPoint.y) {
			awoidWallsVel = new Vector2 (myRigidbody.velocity.x, -maxSpeed);
			nearWall = true;
		}
		
		if (hasBoard && transform.position.x > maxWalkPoint.x) {
			awoidWallsVel = new Vector2 (-maxSpeed, myRigidbody.velocity.y);
			nearWall = true;
		}

		if (hasBoard && transform.position.y < minWalkPoint.y) {
			awoidWallsVel = new Vector2 (myRigidbody.velocity.x, maxSpeed);
			nearWall = true;
		}

		if (hasBoard && transform.position.x < minWalkPoint.x) {
			awoidWallsVel = new Vector2 (maxSpeed, myRigidbody.velocity.y);
			nearWall = true;
		}

		if (nearWall) {
			if (awoidWallsVel.magnitude > maxForce)
				awoidWallsVel.Scale (new Vector3(maxForce, maxForce));
		}
			
		return awoidWallsVel;
	}

	void Update() {

		/*
		if (isChangingDirection) {
			walkCounter -= Time.deltaTime;
			//myRigidbody.velocity = moveVel;

			if (walkCounter < 0) {
				StopWalking ();
			}

		} else {
			//waitCounter -= Time.deltaTime;
			//myRigidbody.velocity = Vector2.zero;

			//if (waitCounter < 0) {
			wanderVel = Seek (GetTargetPosition ());
				//myRigidbody.velocity = moveVel;

			StartWalking ();
			//}
		}
		*/

		shitCounter -= Time.deltaTime;

		if (shitCounter < 0) {
			gameplayManager.CreateShit (new Vector2(transform.position.x, transform.position.y));
			shitCounter = shitTime;
		}


		wanderVel = Wander ();

		myRigidbody.velocity = wanderVel;
		myRigidbody.velocity += AwoidWalls ();

		/*
		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (walkDirection) {
			case 0:
				myRigidbody.velocity = new Vector2 (0, maxSpeed);
				if (hasBoard && transform.position.y > maxWalkPoint.y) {
					StopWalking ();
					myRigidbody.velocity = new Vector2 (0, -maxSpeed);
					ChooseSpecifiedDirection ();
				}
				break;
			case 1:
				myRigidbody.velocity = new Vector2 (maxSpeed, 0);
				if (hasBoard && transform.position.x > maxWalkPoint.x) {
					StopWalking ();
					myRigidbody.velocity = new Vector2 (-maxSpeed, 0);
					ChooseSpecifiedDirection ();
				}
				break;
			case 2:
				myRigidbody.velocity = new Vector2 (0, -maxSpeed);
				if (hasBoard && transform.position.y < minWalkPoint.y) {
					StopWalking ();
					myRigidbody.velocity = new Vector2 (0, maxSpeed);
					ChooseSpecifiedDirection ();
				}
				break;
			case 3:
				myRigidbody.velocity = new Vector2 (-maxSpeed, 0);
				if (hasBoard && transform.position.x < minWalkPoint.x) {
					StopWalking ();
					myRigidbody.velocity = new Vector2 (maxSpeed, 0);
					ChooseSpecifiedDirection ();
				}
				break;
			}

			if (walkCounter < 0) {
				StopWalking ();
			}


		} else {
			waitCounter -= Time.deltaTime;

			myRigidbody.velocity = Vector2.zero;

			if (waitCounter < 0)
				ChooseDirection ();

		}
		*/
			
	}

	/*
	private void ChooseDirection() {
		walkDirection = Random.Range (0, 4);
		StartWalking ();
	}
	*/


	private void StopWalking() {
		isChangingDirection = false;
		//waitCounter = waitTime;
	}

	private void StartWalking() {

		//while (waitCounter > 0) {
		//	waitCounter -= 1;
		//}


		isChangingDirection = true;
		walkCounter = walkTime;
	}

	private Vector3 GetTargetPosition () {
		int posx = Random.Range ((int)minWalkPoint.x, (int)maxWalkPoint.x);
		int posy = Random.Range ((int)minWalkPoint.y, (int)maxWalkPoint.y);

		Vector3 targetPosition = new Vector3 (posx, posy, 0);
		//Debug.Log (targetPosition);
		return targetPosition;
	}

	private Vector2 Seek(Vector3 targetPosition) {
		Vector3 desiredPos = (targetPosition - transform.position).normalized * maxSpeed;
		Vector2 steer = new Vector2(desiredPos.x, desiredPos.y) - myRigidbody.velocity;

		if (steer.magnitude > maxForce)
			steer.Scale (new Vector3(maxForce, maxForce));

		return steer;
	}

}