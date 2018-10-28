using UnityEngine;
using Zenject;

namespace Miautastic.Gameplay.Installers {

	public class GameplayInstaller : MonoInstaller<GameplayInstaller> {

		public override void InstallBindings() {
			Container.Bind<DropHolder> ().FromComponentInHierarchy ().AsSingle ();
			Container.Bind<DolphinHolder>().FromComponentInHierarchy ().AsSingle (); 

			Container.Bind<Vector2> ().FromInstance (Vector2.zero);
			Container.BindFactory<Vector2, Drop, Drop.Factory> ().FromFactory<CustomDropFactory> ();
	    }
			
	}

}