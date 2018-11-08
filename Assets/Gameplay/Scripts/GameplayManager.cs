using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

namespace Miautastic.Gameplay {

	public class GameplayManager : MonoBehaviour {

		#region SerializeFields
		[SerializeField] private int gameOverValue = 20;
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private Canvas canvasOther;
		[SerializeField] private TextMeshPro shooText;
		[SerializeField] private Image blockImage;
		#endregion

		private GameplayPrefabs gameplayPrefabs;
		private DropHolder dropHolder;
		private DolphinHolder dolphinHolder;
		private Drop.Factory dropfactory;
		private State gameplayState;

		private float waitTime = 2f;
		private float timer;
		private bool timerRunning;

		private static GameplayManager instance;

		#region Properties
		public State GameplayState {
			get { return gameplayState; }
		}

		public GameplayPrefabs GameplayPrefabs {
			get { return gameplayPrefabs; }
		}
			
		public DropHolder DropHolder {
			get { return dropHolder; }
		}

		public int GameOverValue {
			get { return gameOverValue; }
		}

		public TextMeshPro ShooText {
			get { return shooText; }
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
		private void Construct (GameplayPrefabs gameplayPrefabs, DropHolder dropHolder, DolphinHolder dolphinHolder, Drop.Factory dropfactory) {
			this.gameplayPrefabs = gameplayPrefabs;
			this.dropHolder = dropHolder;
			this.dolphinHolder = dolphinHolder;
			this.dropfactory = dropfactory;
		}
		#endregion

		#region MonoBehaviour Methods
		void Start() {
			gameplayState = State.PLAY;
			canvasOther.gameObject.SetActive (false);
		}

		void Update() {
			if (timerRunning)
				ShadersInMotion ();
		}
		#endregion

		#region Private Methods
		private void ShadersInMotion() {

			timer += Time.deltaTime;

			if (timer > waitTime) {
				CustomImageEffect[] imageEffects = Camera.main.GetComponents<CustomImageEffect> ();
				foreach (var i in imageEffects)
					i.enabled = true;

				canvasOther.gameObject.SetActive (true);

				timer = 0f;
				timerRunning = false;
			}

		}

		private void GameOverActions() {
			gameplayState = State.GAMEOVER;

			dropHolder.ActivateDrops ();
			dolphinHolder.StopAnimations (true);

			audioSource.pitch = -0.8f;

			blockImage.gameObject.SetActive (true);

			timerRunning = true;

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
