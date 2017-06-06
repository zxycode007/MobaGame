using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class AttackCommand : BaseCommand
	{

		Actor m_target;
		Actor   m_actor;

		public AttackCommand(Actor target, Actor ac)
		{
			m_commandName = "AttackCommand";
			m_target = target;
			m_actor = ac;
		}

		public override void run()
		{
			BeginMoveEvtArg arg = new BeginMoveEvtArg ();
			arg.ac = m_actor;
			arg.position = m_target.transform.position;
			m_actor.FireEvent (m_actor, EventType.EVT_BEGIN_MOVE, arg);
		}

		public override void update()
		{
			if(!m_isRunning)
			{
				run ();
			}
			if(m_target == null || m_target.state == ActorState.DEAD || m_actor.state == ActorState.DEAD)
			{
				StopMoveEvtArg arg = new StopMoveEvtArg ();
				arg.ac = m_actor;
				m_actor.FireEvent (m_actor,EventType.EVT_STOP_MOVE, arg);
				m_bFinished = true;
				return;
			}
			if(Vector3.Distance(m_target.transform.position, m_actor.transform.position) > m_actor.attackRange)
			{
				BeginMoveEvtArg arg = new BeginMoveEvtArg ();
				arg.ac = m_actor;
				arg.position = m_target.transform.position;
				m_actor.FireEvent (m_actor, EventType.EVT_BEGIN_MOVE, arg);

			}else
			{
				//Debug.Log("AttackCommand : BeginAttackEvent");
				BeginAttackEvtArg arg = new BeginAttackEvtArg ();
				arg.attackerID = m_actor.transform.GetInstanceID ();
				arg.targetID = m_target.transform.GetInstanceID ();
				arg.ac = m_actor;
				arg.target = m_target;
				m_actor.FireEvent (this, EventType.EVT_BEGIN_ATTACK, arg);
			}


		}
	}
}


