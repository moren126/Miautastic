using Zenject;
using Miautastic.Menu;
using Miautastic.Menu.States;

namespace Miautastic.Menu.Installers {

	public class GameInstaller : MonoInstaller<GameInstaller> {
	    
		public override void InstallBindings() {
			InstallMenuManager ();
	    }

		private void InstallMenuManager() {
			Container.Bind<GameStateFactory> ().AsSingle ();

			Container.BindInterfacesAndSelfTo<PlayState> ().AsSingle ();
			Container.BindInterfacesAndSelfTo<HelpState> ().AsSingle ();
			Container.BindInterfacesAndSelfTo<CreditsState> ().AsSingle ();
			Container.BindInterfacesAndSelfTo<ExitState> ().AsSingle ();

			Container.BindFactory<PlayState, PlayState.Factory> ().WhenInjectedInto<GameStateFactory> ();
			Container.BindFactory<HelpState, HelpState.Factory> ().WhenInjectedInto<GameStateFactory> ();
			Container.BindFactory<CreditsState, CreditsState.Factory> ().WhenInjectedInto<GameStateFactory> ();
			Container.BindFactory<ExitState, ExitState.Factory> ().WhenInjectedInto<GameStateFactory> ();
		}

	}

}