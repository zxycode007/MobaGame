using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables;

namespace MobaGame
{
	public class IsAlive : Conditional {

		Actor actor;

		public override void OnAwake()
		{
			if(gameObject != null)
			{
				actor = gameObject.GetComponent<Actor> ();
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (gameObject != null)
			{
				if(actor.state != ActorState.DEAD)
				{
					return TaskStatus.Success;
				}

			}
			return TaskStatus.Failure;
		}
	}
}

