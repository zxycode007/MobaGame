using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MobaGame
{
	public class MainMenuState : BaseSceneState
	{
		public MainMenuState(SceneController controller):base(controller)
		{
			this.m_sceneName = "MainMenuScene";
			this.m_eState = ESceneState.E_SCENE_STATE_MAIN_MENU;
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		public override void SceneStateBegin()
		{
			m_bRunState = true;
			GameObject btnObj = GameObject.Find ("StartGameBtn");
			if(btnObj != null)
			{
				Button btn = btnObj.GetComponent<Button> ();
				btn.onClick.AddListener (() => OnClickStartBtn (btn));
			}

		}

		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if(scene.name == m_sceneName)
			{
				m_bIsLoaded = true;
			}
		}

		private void OnClickStartBtn(Button btn)
		{
			Debug.Log ("开始游戏!");
			m_controller.SetSceneState (new GameState (m_controller));
		}

		public override void SceneStateEnd()
		{

		}

		public override void SceneStateUpdate()
		{

		}
	}
}


