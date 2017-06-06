using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MobaGame
{
	public enum ESceneState
	{
		E_SCENE_STATE_MAIN_MENU,
		E_SCENE_STATE_GAME
	}
	public class SceneController 
	{
		private bool m_bSceneLoaded = false;
		private BaseSceneState m_state;

		public SceneController()
		{
			m_state = new MainMenuState (this);
			m_state.SceneStateBegin ();
		}

		public void SetSceneState(BaseSceneState sceneState)
		{
			if(m_state.GetESceneState() != sceneState.GetESceneState())
			{
				m_bSceneLoaded = false;
				m_state = sceneState;
				//执行上一个场景的结束
				m_state.SceneStateEnd ();
				LoadScene (m_state.GetSceneName ());
			}
		}



		private void LoadScene(string sceneName)
		{
			SceneManager.LoadScene (sceneName);
		}


		public void UpdateSceneState()
		{
			if(m_state == null || m_state.isLoaded()==false)
			{
				return;
			}

			if(m_state.isRunning() == false)
			{
				m_state.SceneStateBegin ();
			}

			m_state.SceneStateUpdate ();
		}

	}
}


