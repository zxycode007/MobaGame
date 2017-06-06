using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class CastSpellActorState : BaseActorState {

		public CastSpellActorState(Actor ac):base(ac)
		{
			m_stateName = "CastSpellActorState";
			m_state = ActorState.CASTSPELL;
		}

		// Update is called once per frame
		public override void Update () 
		{
			m_actor.agent.destination = m_actor.transform.position;
			m_actor.anim.SetInteger ("ActorState", 2);
		}
	}
}

