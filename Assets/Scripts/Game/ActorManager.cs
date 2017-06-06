using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace MobaGame
{
	public class ActorManager  : GameContext
	{
		Actor m_playerUnit;
        List<Actor> m_actors;
		public Actor GetPlayerActor()
		{
			return m_playerUnit;
		}

		void Init()
		{
            m_actors = new List<Actor>();
			GameObject obj = Global.prefabData ["player"];
			GameObject spwanPoint = Global.GetSpawnPointA ();
			if(obj != null)
			{
				GameObject player = Instantiate(obj, spwanPoint.transform.position, spwanPoint.transform.rotation) as GameObject;
				if(player != null)
				{
					m_playerUnit = player.GetComponent<Actor> ();
                    m_actors.Add(m_playerUnit);
					Global.GetCameraManager ().SetFollowTarget (m_playerUnit.gameObject.transform);
				}
			}
		}

        public void AddActor(Actor ac)
        {
            if(!m_actors.Contains(ac))
            {
                m_actors.Add(ac);
            }
        }

		void Start()
		{
			Init ();
		}
		 
		public void Update()
		{
           
            for (int i = m_actors.Count - 1; i >= 0; i--)
            {
                if (m_actors[i] == null || m_actors[i].GetState() == ActorState.DEAD)
                {
                    m_actors.Remove(m_actors[i]);
                    continue;
                }
                m_actors[i].GetCommandManager().Update();
            }
        }
	}
}

