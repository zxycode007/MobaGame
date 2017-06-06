using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class AttackActorState : BaseActorState {

		Actor m_tragetUnit;
		public AttackActorState(Actor ac, Actor targetUnit):base(ac)
		{
			m_stateName = "AttackActorState";
			m_state = ActorState.ATTACK;
			m_tragetUnit = targetUnit;
		}


		// Update is called once per frame
		public override void Update ()
		{
			m_actor.agent.destination = m_actor.transform.position;
			if(m_tragetUnit != null && m_tragetUnit.GetCurState()!=ActorState.DEAD)
			{
				m_actor.anim.SetInteger ("ActorState", 1);
			}else{
				m_actor.SetState (new IdleActorState (m_actor));
			}


		}
	}
}

