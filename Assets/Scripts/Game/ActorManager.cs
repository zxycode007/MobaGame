using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class ActorManager  : GameContext
	{
		Actor m_playerUnit;
		public Actor GetPlayerActor()
		{
			return m_playerUnit;
		}

		void Init()
		{
			GameObject obj = Global.prefabData ["player"];
			GameObject spwanPoint = Global.GetSpawnPointA ();
			if(obj != null)
			{
				GameObject player = Instantiate(obj, spwanPoint.transform.position, spwanPoint.transform.rotation) as GameObject;
				if(player != null)
				{
					m_playerUnit = player.GetComponent<Actor> ();
					Global.GetCameraManager ().SetFollowTarget (m_playerUnit.gameObject.transform);
				}
			}
		}



		void Start()
		{
			Init ();
		}
		 
		public void Update()
		{
			m_playerUnit.GetCommandManager ().Update ();
		}
	}
}

