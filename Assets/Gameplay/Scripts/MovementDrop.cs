using System.Collections;
using UnityEngine;
using Zenject;

public class MovementDrop : MonoBehaviour {

	private bool isActivated;

	private float maxSpeed = 100f;
	private float slowingRadius = 100f;

	private Rigidbody2D myRigidbody;
	private Vector2 dropVel;
	private GameObject endPos;

	public bool IsActivated {
		//get { return isActivated; }
		set { isActivated = value; }
	}
		
	void Start() {
		isActivated = false;
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
		
	void Update() {
		
		if (isActivated) {
			int number = Random.Range (0, CatHolder.GetCatsList);

			endPos = CatHolder.DCP (number);

			GetComponent<SpriteRenderer>().sortingOrder = 2;

			isActivated = false;
		}
			
		if (endPos != null) {
			//Debug.Log (endPos.GetComponent<Rigidbody2D>().position);

			Vector2 pos = endPos.GetComponent<RectTransform> ().anchoredPosition/90f; //transform.parent.localPosition / 24f;

			dropVel = Arrive (pos);
			myRigidbody.velocity = dropVel;
		}

	}

	private Vector2 Arrive(Vector2 targetPos) {

		Vector2 desiredVelocity;

		Vector2 toTarget = targetPos - myRigidbody.position;
		float dist = toTarget.magnitude;

		if (dist < slowingRadius)	
			desiredVelocity = Vector2.ClampMagnitude(toTarget, 1f) * maxSpeed * (dist/slowingRadius);
		else
			return desiredVelocity = Vector2.ClampMagnitude(toTarget, 1f) * maxSpeed;

		return desiredVelocity;
	}

}