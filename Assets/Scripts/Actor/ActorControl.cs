using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using MobaGame;

//public enum UserOrder
//{
//	SELECT_TARGET,
//	MOVE_TO
//}



public class ActorControl : MonoBehaviour {


//	public Animator animator;
//	public NavMeshAgent agent;
//	public Image  NavigatorIcon;
//	Actor actor;

	// Use this for initialization
	void Start () {

//		actor = GetComponent<Actor> ();
//		agent = GetComponent<NavMeshAgent> ();
		//NavigatorIcon.enabled = false;
		//GameContext.StopMoveHandler += OnStopMove;


	}

	void OnStopMove(object sender, EventArgs args)
	{
//		Actor ac = sender as Actor;
//		if(ac.transform == this.transform)
//		{
//			//Debug.Log ("移动停止!");
//			//NavigatorIcon.enabled = false;
//		}

	}

	//处理用户输入
	void  HandleInput()
	{
//		if(Input.GetButtonDown("Fire2"))
//		{
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//			if(Physics.Raycast(ray, out hit, 200))
//			{
//                Vector3 pos = hit.point;
//                //if(hit.transform.tag == "Terrian")
//                //{
//                //    //点击地面
//                //    actor.moveToOrder(pos);
//                //}else if(hit.transform.tag == "assailable")
//                //{
//                //    //可攻击的目标
//                //    actor.AttackTargetOrder(hit.transform);
//					 
//                //}
//                //Vector3 screenPos = Camera.main.WorldToScreenPoint (pos);
//                //NavigatorIcon.transform.position = screenPos;
//                //NavigatorIcon.enabled = true;
//			}
//		}
//		if(Input.GetButtonDown("Fire1"))
//		{
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//			if(Physics.Raycast(ray, out hit, 200))
//			{
//				if(hit.transform.tag == "assailable" && actor.curSkillSlot != -1)
//				{
//					actor.CastSpellToTargetOrder(hit.transform, actor.curSkillSlot);
//				}
//			}
//			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
//		}
		
	}

	// Update is called once per frame
	void Update () {
		    
		//HandleInput ();
		//Vector3 screenPos = Camera.main.WorldToScreenPoint (agent.destination);
		//NavigatorIcon.transform.position = screenPos;

         

    }
		
}
