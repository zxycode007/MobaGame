using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MobaGame
{
	public class DeadActorState : BaseActorState {

		public DeadActorState(Actor ac):base(ac)
		{
			m_stateName = "DeadActorState";
			m_state = ActorState.DEAD;
		}

		// Update is called once per frame
		public override void Update (){

			m_actor.agent.destination = m_actor.transform.position;
			m_actor.anim.SetInteger ("ActorState", 3);
		}
	}
}

