using System.Collections;
using UnityEngine;
using Zenject;

namespace Miautastic.Gameplay {

	public class Cat : MonoBehaviour {

		#region Serialize Fields
		[SerializeField] private float maxSpeed;
		[SerializeField] private float maxForce;
		[SerializeField] private float walkTime;
		[SerializeField] private bool isChangingDirection;
		[SerializeField] private Collider2D board;
		#endregion

		private Rigidbody2D myRigidbody;

		private float walkCounter;
		private float dropTime;
		private float dropCounter;

		private int walkDirection;

		private Vector2 wanderVel;
		private Vector2 minWalkPoint;
		private Vector2 maxWalkPoint;

		private bool hasBoard;

		private GameplayManager gameplayManager;

		#region MonoBehaviour methods
		void Start() {
			gameplayManager = GameplayManager.Instance;

			myRigidbody = GetComponent<Rigidbody2D> ();

			walkCounter = walkTime;

			dropTime = Random.value * 20f;
			dropCounter = dropTime;

			StartWalking ();

			if (board != null) {
				minWalkPoint = board.bounds.min;
				maxWalkPoint = board.bounds.max;
				hasBoard = true;
			}
		}

		void Update() {

			if (GameplayManager.Instance.GameplayState == State.PLAY) {

				dropCounter -= Time.deltaTime;

				if (dropCounter < 0) {
					gameplayManager.CreateDrop (new Vector2 (transform.position.x, transform.position.y));
					dropCounter = dropTime;
				}


				wanderVel = Wander ();

				myRigidbody.velocity = wanderVel;
				myRigidbody.velocity += AwoidWalls ();

			}

			if (GameplayManager.Instance.GameplayState == State.GAMEOVER) {
				float vectorXTemp = myRigidbody.velocity.x / 10;
				float vectorYTemp = myRigidbody.velocity.y / 10;
				myRigidbody.velocity = new Vector2 (vectorXTemp, vectorYTemp);
			}

		}
		#endregion

		#region Private methods
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
			
		private void StopWalking() {
			isChangingDirection = false;
		}

		private void StartWalking() {
			isChangingDirection = true;
			walkCounter = walkTime;
		}

		private Vector3 GetTargetPosition () {
			int posx = Random.Range ((int)minWalkPoint.x, (int)maxWalkPoint.x);
			int posy = Random.Range ((int)minWalkPoint.y, (int)maxWalkPoint.y);

			Vector3 targetPosition = new Vector3 (posx, posy, 0);

			return targetPosition;
		}

		private Vector2 Seek(Vector3 targetPosition) {
			Vector3 desiredPos = (targetPosition - transform.position).normalized * maxSpeed;
			Vector2 steer = new Vector2(desiredPos.x, desiredPos.y) - myRigidbody.velocity;

			if (steer.magnitude > maxForce)
				steer.Scale (new Vector3(maxForce, maxForce));

			return steer;
		}
		#endregion
	}

}