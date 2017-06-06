using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class BaseSceneState 
	{
		protected string m_sceneName;
		// Use this for initialization
		protected ESceneState m_eState;
		protected SceneController m_controller;
		protected bool m_bRunState = false;
		protected bool m_bIsLoaded = false;

		public BaseSceneState(SceneController controller)
		{
			m_controller = controller;
			m_eState = ESceneState.E_SCENE_STATE_MAIN_MENU;
		}

		public string GetSceneName()
		{
			return m_sceneName;
		}

		public ESceneState GetESceneState()
		{
			return m_eState;
		}

		public bool isLoaded()
		{
			return m_bIsLoaded;
		}

		public bool isRunning()
		{
			return m_bRunState;
		}

		public virtual void SceneStateBegin()
		{
			
		}

		public virtual void SceneStateEnd()
		{
			
		}

		public virtual void SceneStateUpdate()
		{
			
		}
		 
	}
}


