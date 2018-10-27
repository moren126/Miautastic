using System.Collections;
using UnityEngine;
using Zenject;

namespace Miautastic.Gameplay {

	public class GameplayManager : MonoBehaviour {

		#region SerializeFields
		[SerializeField] private int gameOverValue = 20;
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private Canvas canvasOther;
		#endregion

		private DropHolder dropHolder;
		private DolphinHolder dolphinHolder;
		private Drop.Factory dropfactory;
		private State gameplayState;

		private static GameplayManager instance;

		#region Properties
		public State GameplayState {
			get { return gameplayState; }
		}
			
		public DropHolder DropHolder {
			get { return dropHolder; }
		}

		public int GameOverValue {
			get { return gameOverValue; }
		}
			
		public static GameplayManager Instance {
			get {
				if (instance == null)
					instance = FindObjectOfType<GameplayManager> ();
				return instance;
			}
		}
		#endregion

		#region Inject
		[Inject]
		private void Construct (DropHolder dropHolder, DolphinHolder dolphinHolder, Drop.Factory dropfactory) {
			this.dropHolder = dropHolder;
			this.dolphinHolder = dolphinHolder;
			this.dropfactory = dropfactory;
		}
		#endregion

		#region MonoBehaviour Methods
		private void Start() {
			gameplayState = State.PLAY;
			canvasOther.gameObject.SetActive (false);
		}
		#endregion

		#region Private Methods
		private IEnumerator ShadersInMotion(float waitTime) {

			yield return new WaitForSeconds (waitTime);

			CustomImageEffect[] imageEffects = Camera.main.GetComponents<CustomImageEffect> ();
			foreach (var i in imageEffects)
				i.enabled = true;

			canvasOther.gameObject.SetActive (true);
		}

		private void GameOverActions() {
			gameplayState = State.GAMEOVER;

			dropHolder.ActivateDrops ();
			dolphinHolder.StopAnimations (true);

			audioSource.pitch = -0.8f;

			StartCoroutine(ShadersInMotion (2f));

			if (PlayerPrefs.GetInt ("highscore") == 0) {
				PlayerPrefs.SetInt ("highscore", dropHolder.GetPoints);
			} else if (PlayerPrefs.GetInt ("highscore") < dropHolder.GetPoints)
				PlayerPrefs.SetInt ("highscore", dropHolder.GetPoints);
		}
		#endregion

		#region Public Methods 
		public void CreateDrop(Vector2 position) {

			if (gameplayState == State.PLAY) {

				if (dropHolder.GetDropClickedCount == 0) { 

					Drop drop = dropfactory.Create (position);

					dropHolder.AddDrop (drop.gameObject);
				} else {
					dropHolder.AddDropPooling (position);
				}

				if (dropHolder.GetDropCount >= gameOverValue) {
					GameOverActions ();
				}

			}
		}
		#endregion
	}

}
