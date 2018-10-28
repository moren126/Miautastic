using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Miautastic.Gameplay {

	public class Drop : MonoBehaviour {

		[SerializeField] Sprite spriteHighlighted;
		[SerializeField] Sprite spriteActivated;
		private Sprite spriteOriginal;

		private bool isActivated;

		private float maxSpeed = 100f;
		private float slowingRadius = 100f;

		private Rigidbody2D myRigidbody;
		private Vector2 dropVel;
		private GameObject endPos;

		[Inject]
		public Vector2 position;

		public bool IsActivated {
			//get { return isActivated; }
			set { isActivated = value; }
		}
			
		void Start() {
			isActivated = false;
			myRigidbody = GetComponent<Rigidbody2D> ();
			spriteOriginal = GetComponent<SpriteRenderer> ().sprite;

			GetComponent<RectTransform> ().SetParent (GameObject.Find("DropHolder").transform, true);
			GetComponent<RectTransform> ().anchoredPosition = position;
			GetComponent<RectTransform> ().localScale = new Vector3 (4f, 4f);
		}
			
		void Update() {
			
			if (isActivated) {
				int number = Random.Range (0, CatHolder.GetCatsList);

				endPos = CatHolder.DCP (number);

				GetComponent<SpriteRenderer> ().sprite = spriteActivated;
				GetComponent<SpriteRenderer>().sortingOrder = 2;

				GetComponent<EventTrigger> ().enabled = false;

				isActivated = false;
			}
				
			if (endPos != null) {
				Vector2 pos = endPos.GetComponent<RectTransform> ().anchoredPosition/90f;

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

		public void RemoveMouseOnClick() {
			//drop shouldn't move
			isActivated = false;

			//come back to original sprite
			GetComponent<SpriteRenderer> ().sprite = spriteOriginal;

			//drop shoudn't be visible
			gameObject.SetActive (false);

			//logic of removal is in dropHolder
			GameplayManager.Instance.DropHolder.RemoveDrop (this.gameObject);
		}

		public void HighlightMouse(bool highligt) {
			if (highligt)
				GetComponent<SpriteRenderer> ().sprite = spriteHighlighted;
			else
				GetComponent<SpriteRenderer> ().sprite = spriteOriginal;
		}


		public class Factory : Factory<Vector2, Drop> {

		}
	}

}