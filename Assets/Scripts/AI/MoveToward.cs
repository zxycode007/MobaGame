using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables;

namespace MobaGame
{
	public class MoveToward : Action {

		public float speed;
		//这个target应该在MoveToward任务之前 由WithSight 任务设置
		public SharedTransform target;
		Actor actor;

		public override void OnAwake()
		{
			actor = gameObject.GetComponent<Actor> ();
			speed = actor.speed;
		}

		//做实际的移动
		public override TaskStatus OnUpdate()
		{
			if(gameObject == null)
			{
				return TaskStatus.Failure;
			}
			if(Vector3.Distance(transform.position,target.Value.position) < actor.attackRange)
			{
				return TaskStatus.Success;
			}
			//transform.position = Vector3.MoveTowards (transform.position, target.Value.position, speed* Time.deltaTime);
			CommandManager mgr = actor.GetCommandManager ();
			mgr.Clear ();
			mgr.AddCommand (new AttackCommand(target.Value.GetComponent<Actor>(), actor));
            Debug.Log("AI 攻击命令!");
			//actor.AttackTargetOrder (target.Value);
			return TaskStatus.Running;
		}

	}
}

