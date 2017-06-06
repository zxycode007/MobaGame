using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class MovingActorState : BaseActorState
	{
		public MovingActorState(Actor ac):base(ac)
		{
			m_stateName = "MovingActorState";
			m_state = ActorState.MOVING;
		}
		 

		// Update is called once per frame
		public override void Update ()
		{
			if(Vector3.Distance(m_actor.agent.destination, m_actor.transform.position) < 0.5)
			{
				m_actor.SetState (new IdleActorState (m_actor));
				
			}else
			{
				m_actor.anim.SetInteger ("ActorState", 4);
			}

		}


	}
}


