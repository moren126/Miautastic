using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace FSM.GameManager.States {

	public class MenuState : GameStateEntity {

		public override void Initialize() {
			Debug.Log ("MenuState Initialized");
		}

		public override void Start() {
			Debug.Log ("MenuState Started");
			SceneManager.LoadScene ("gameplay");
		}

		public override void Tick() {}

		public override void Dispose() {
			Debug.Log ("MenuState Disposed");
		}

		public class Factory : Factory<MenuState> {}

	}

}
