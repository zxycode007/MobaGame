using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public enum ActorState
	{
		IDLE = 0,
		MOVING,
		ATTACK,
		CASTSPELL,
		DEAD,
		OTHER
	}
	
	public class BaseActorState : object
	{

		protected string m_stateName;
		protected Actor  m_actor;
		protected ActorState m_state;

		public BaseActorState(Actor ac)
		{
			m_actor = ac;
			m_stateName = "BaseActorState";
			m_state = ActorState.OTHER;
		}

		public string GetStateName()
		{
			return m_stateName;
		}

		public ActorState GetState()
		{
			return m_state;
		}

		// Update is called once per frame
		public virtual void Update ()
		{

		}
	}
}



