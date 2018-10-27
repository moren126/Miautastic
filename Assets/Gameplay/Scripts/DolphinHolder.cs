using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Miautastic.Gameplay {

	public class DolphinHolder : MonoBehaviour {

		[SerializeField] private GameObject dolphinLeft; 
		[SerializeField] private GameObject dolphinRight; 

		private Animator dolphinLeftAnimator;
		private Animator dolphinRightAnimator;

		void Start () {
			dolphinLeftAnimator = dolphinLeft.GetComponent<Animator> ();
			dolphinRightAnimator = dolphinRight.GetComponent<Animator> ();
		}

		public void StopAnimations(bool stopAnimations) {

			if (stopAnimations) {
				dolphinLeftAnimator.speed = 0;
				dolphinRightAnimator.speed = 0;
			} else {
				dolphinLeftAnimator.speed = 1f;
				dolphinRightAnimator.speed = 1f;
			}
		}

	}

}
