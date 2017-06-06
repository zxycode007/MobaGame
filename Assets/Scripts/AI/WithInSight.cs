using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables;

namespace MobaGame
{
	//自定义Condition
	public class WithinSight : Conditional {

		//对象视野
		public float  fieldOfViewAngle;
		//对象要移动的方向的target标志
		public string targetTag;
		//
		public SharedTransform target;
		//缓冲所有有targetTag的Transform
		private Transform[] possibleTarget;

		//在Behavior Tree 刚打开的时候调用
		//找出所有targetTag的GameObject
		public override void OnAwake ()
		{
			//查找所有目标标志的target
			var targets = GameObject.FindGameObjectsWithTag (targetTag);
			possibleTarget = new Transform[targets.Length];
			for(int i=0; i<targets.Length; i++)
			{
				possibleTarget [i] = targets [i].transform;
			}
			//base.OnAwake ();
		}


		public override TaskStatus OnUpdate()
		{
			if(gameObject == null)
			{
				return TaskStatus.Failure;
			}
			Collider[] colliders =  Physics.OverlapSphere (transform.position, 5.0F);
			for(int i=0 ; i< colliders.Length; i++)
			{
				if(colliders[i].gameObject.tag == "Player")
				{
                    Debug.LogWarning("发现Player"+colliders[i].gameObject.GetComponent<Actor>().creatureName);
					target.Value = colliders [i].transform;
					if(WithInSight(target.Value, fieldOfViewAngle))
					{
						return TaskStatus.Success;
					}
				}
			}
//			for(int i=0; i<possibleTarget.Length; i++)
//			{
//				if(WithInSight(possibleTarget[i].transform, fieldOfViewAngle))
//				{
//					target.Value = possibleTarget [i].transform;
//					return TaskStatus.Success;
//				}
//			}
			return TaskStatus.Failure;
		}

		//判断是否在视角以内
		public bool WithInSight(Transform targetTransform, float fieldOfViewAngle)
		{
			Vector3 direction = targetTransform.position - transform.position;
			return Vector3.Angle (direction, transform.forward) < fieldOfViewAngle;
		}
	 
	}

	
}
