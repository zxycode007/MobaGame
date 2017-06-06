using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class GameLoop : GameContext
	{
		//玩家重生时间
		public float playerRespawnTime;
		private SceneController m_sceneController;
		void Awake()
		{
			GameObject.DontDestroyOnLoad( this.gameObject );
		}
		// Use this for initialization
		void Start ()
		{
			m_sceneController = new SceneController ();
		}

		 
		void HandleInput()
		{
			if(Input.GetButtonDown("Fire2"))
			{
				FireEvent (this,EventType.EVT_MOUSE_FIRE2_EVT, new MouseFire2EvtArg ());
			}
			if(Input.GetButtonDown("Fire1"))
			{
				FireEvent (this, EventType.EVT_MOUSE_FIRE1_EVT, new MouseFire1EvtArg ());
			}
		}
		// Update is called once per frame
		void Update ()
		{
			HandleInput ();
			m_sceneController.UpdateSceneState ();
		}
	}
}


