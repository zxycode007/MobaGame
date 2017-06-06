using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class MoveToCommand : BaseCommand
	{
		Vector3 m_position;
		Actor   m_actor;


		public MoveToCommand(Vector3 position, Actor ac)
		{
			m_commandName = "MoveToCommand";
			m_position = position;
			m_actor = ac;
		}
	 
		public override void run()
		{
			BeginMoveEvtArg arg = new BeginMoveEvtArg ();
			arg.ac = m_actor;
			arg.position = m_position;
			m_actor.FireEvent (m_actor, EventType.EVT_BEGIN_MOVE, arg);
			this.m_isRunning = true;
		}

		public override void update()
		{
			if(!m_isRunning)
			{
				run ();
			}
			if(Vector3.Distance(m_position, m_actor.transform.position) <= Global.MinUnitDistance)
			{
				m_bFinished = true;
				StopMoveEvtArg arg = new StopMoveEvtArg ();
				arg.ac = m_actor;
				m_actor.FireEvent (m_actor, EventType.EVT_STOP_MOVE, arg);
				return;
			}
			m_actor.agent.SetDestination (m_position);

		}
	
	}
}


