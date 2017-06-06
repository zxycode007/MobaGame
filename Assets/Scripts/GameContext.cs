using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace MobaGame
{

	public enum EventType
	{
		EVT_STOP_MOVE,
		EVT_BEGIN_MOVE,
		EVT_ATTACK_TO,
		EVT_BEGIN_ATTACK,
		EVT_END_ATTACK,
		EVT_UNIT_DIE,
		EVT_PREPARE_CAST_SPELL,
		EVT_BEGIN_CAST_SPELL,
		EVT_END_CAST_SPELL,
		EVT_BEGIN_SKILL_EFFECT,
		EVT_BE_DAMAGED,
		EVT_BUFF_IS_OVER,
		EVT_ADD_BUFF,
		EVT_REMOVE_BUFF,
		EVT_REMOVE_BUFF_ICON,

		//操作事件
		EVT_MOUSE_FIRE1_EVT,
		EVT_MOUSE_FIRE2_EVT
	}

	public class StopMoveEvtArg : EventArgs
	{
		public Actor ac;
	}

	public class BeginMoveEvtArg: EventArgs
	{
		public Actor ac;
		public Vector3 position;
	}

	public class AttackToEvtArg: EventArgs
	{
		public Actor ac;
		public Actor target;
	}

	public class BeginAttackEvtArg : EventArgs
	{
		public int attackerID;
		public int targetID;
		public Actor ac;
		public Actor target;
	}

	public class BeginCastSpellArg :EventArgs
	{
		public int  casterID;
		public int  skillID;

	}

	public class EndCastSpellArg :EventArgs
	{
		public int  casterID;
		public int  skillID;

	}

	public class BeginSpellEffectArg :EventArgs
	{
		public int casterID;
		public int targetID;
		public Vector2  targetPos;
		public int skillID;
	}
		

	public class EndAttackEvtArg : EventArgs
	{
		public int attackerID;
		public int targetID;
	}
		
	public class UnitDieEvtArg : EventArgs
	{
		public Actor deadUnit;
		public Actor killerUnit;
		public int deadUnitID;
		public int murdererID;
		
	}

	public class BeDamageEvtArg : EventArgs
	{
		public int srcUnitID;
		public int descUnitID;
		public float value;
	}


	public class BuffIsOverEvtArg : EventArgs
	{
		public int ownerID;
		public int casterID;
		public int buffID;
	}

	public class AddBuffEvtArg : EventArgs
	{
		public int ownerID;
		public int casterID;
		public int buffID;
	}

	public class RemoveBuffEvtArg : EventArgs
	{
		public int ownerID;
		public int casterID;
		public int buffID;
		public int count;
	}

	public class RemoveBuffIconEvtArg : EventArgs
	{		 
		public int buffID;
		public int count;
	}

	public class MouseFire1EvtArg : EventArgs
	{
		//public RaycastHit hit;

	}

	public class MouseFire2EvtArg : EventArgs
	{
		//public RaycastHit hit;
	}
	 
	public class GameContext : MonoBehaviour
	{
		//事件
		//停止移动
		public static event EventHandler StopMoveHandler;
		public static event EventHandler BeginMoveHandler;
		public static event EventHandler AttackToHandler;
		//开始攻击
		public static event EventHandler BeginAttackHandler;
		//攻击结束
		public static event EventHandler EndAttackHandler;
		//单位死亡
		public static event EventHandler UnitDieHandler;
		//单位开始释放一个技能
		public static event EventHandler BeginCastSpellHandler;
		//单位结束释放一个技能
		public static event EventHandler EndCastSpellHandler;
		//开始一种技能效果
		public static event EventHandler BeginSkillEffectHandler;

		public static event EventHandler BeDamagedHandler;

		public static event EventHandler BuffIsOverHandler;

		public static event EventHandler AddBuffHandler;

		public static event EventHandler RemoveBuffHandler;

		public static event EventHandler RemoveBuffIconHandler;

		public static event EventHandler MouseFire1Handler;

		public static event EventHandler MouseFire2Handler;



		public void FireEvent(object sender,EventType type, EventArgs arg)
		{
			switch(type)
			{
			case(EventType.EVT_ATTACK_TO):
				{
					if(AttackToHandler != null)
					{
						AttackToHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_BEGIN_MOVE):
				{
					if(BeginMoveHandler != null)
					{
						BeginMoveHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_STOP_MOVE):
				{
					if(StopMoveHandler != null)
					{
					  StopMoveHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_BEGIN_ATTACK):
				{
					if(BeginAttackHandler != null)
					{
						BeginAttackHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_END_ATTACK):
				{
					if(EndAttackHandler != null)
					{
						EndAttackHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_UNIT_DIE):
				{
					if(UnitDieHandler != null)
					{
						UnitDieHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_BEGIN_CAST_SPELL):
				{
					if(BeginCastSpellHandler != null)
					{
						BeginCastSpellHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_END_CAST_SPELL):
				{
					if(EndCastSpellHandler != null)
					{
						EndCastSpellHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_BEGIN_SKILL_EFFECT):
				{
					if(BeginSkillEffectHandler != null)
					{
						BeginSkillEffectHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_BE_DAMAGED):
				{
					if(BeDamagedHandler != null)
					{
						BeDamagedHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_BUFF_IS_OVER):
				{
					if(BuffIsOverHandler != null)
					{
						BuffIsOverHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_ADD_BUFF):
				{
					if(AddBuffHandler != null)
					{
						AddBuffHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_REMOVE_BUFF):
				{
					if(RemoveBuffHandler != null)
					{
						RemoveBuffHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_REMOVE_BUFF_ICON):
				{
					if(RemoveBuffIconHandler != null)
					{
						RemoveBuffIconHandler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_MOUSE_FIRE1_EVT):
				{
					if(MouseFire1Handler != null)
					{
						MouseFire1Handler (sender, arg);
					}
					break;
				}
			case(EventType.EVT_MOUSE_FIRE2_EVT):
				{
					if(MouseFire2Handler != null)
					{
						MouseFire2Handler (sender, arg);
					}
					break;
				}

			}
			 
		}
		  
		 

	}

}

