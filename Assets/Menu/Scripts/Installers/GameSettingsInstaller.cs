using System;
using UnityEngine;
using Zenject;
using Miautastic.Menu.States;

namespace Miautastic.Menu.Installers {

	[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
	public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller> {
	    
		public GameStateSettings gameState;

		[Serializable]
		public class GameStateSettings {

		}
			
		public override void InstallBindings() {

	    }
	}

}