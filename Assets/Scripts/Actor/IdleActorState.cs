using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class IdleActorState : BaseActorState
	{

		public IdleActorState(Actor ac):base(ac)
		{
			m_stateName = "IdleActorState";
			m_state = ActorState.IDLE;
		}
		 

		// Update is called once per frame
		public override void Update ()
		{
			m_actor.agent.destination = m_actor.transform.position;
			m_actor.anim.SetInteger ("ActorState", 0);
		}
	}
}


