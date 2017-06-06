using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MobaGame;
using UnityEditor;

namespace MobaGame
{
	

	public enum ActorOrder
	{
		NO_ORDER,
		HOLD_ORDER,
		STOP_ORDER,
		MOVETO_ORDER,
		ATTACK_ORDER,
		FOLLOW_ORDER,
		SPELLTO_ORDER
	}

    public class AnimationControlParamter
    {
        //动画时间缩放
        public float timeScale {get;set;}
        public bool  bLoop {get; set;}
    }

	public class Actor : Creature {

		public int  curSkillSlot;
		public NavMeshAgent agent;
		public Animator      anim;
		public ActorState state;
        public string assetName;
		private BaseActorState m_state;
        
		private CommandManager m_cmdMgr;
        //默认的动画参数
        private Hashtable defaultAnimationParamters;
		//临时保存的目标单位
		private Transform targetUnit;
		//当前使用技能槽索引
        private int curUseSkillIndex;
		//命令
		private ActorOrder order;

		public void loadAsset(string name)
		{
			string path = "Assets/Resource/Data/Creatures/" + name + ".asset";
			Load (path);
			//BeginAttack += OnBeAttacked;
		}
		public Actor()
		{
			Debug.LogWarning ("创建Actor!");
		}

		public void SetNavMeshAgent(NavMeshAgent nma)
		{
			agent = nma;
		}

		public void SetAnimator(Animator animator)
		{
			anim = animator;
		}

		public void SetCurUseSkillIndex(int index)
		{
			this.curUseSkillIndex = index;
		}

		public int GetCurUseSkillIndex()
		{
			return this.curUseSkillIndex;
		}

		//改变移动速度
		public void changeSpeed(float spd)
		{
			speed = spd;
			agent.speed = spd;
			AnimationControlParamter acp =  GetAnimationParamter ("Run");
			acp.timeScale = speed / defaultData.speed;
			SetAnimationParamter ("Run", acp);
		}
		//改变攻击速度
		public void changeAttackSpeed(float aspd)
		{
			attackSpeed = aspd;
			AnimationControlParamter acp =  GetAnimationParamter ("AttackNormal");
			acp.timeScale = aspd;
			SetAnimationParamter ("AttackNormal", acp);
		
		}
        //设置技能到角色技能槽
        public void SetSkill(int index, int skillId)
        {
            if(Global.SkillData.ContainsKey(skillId))
            {
                SkillItem item = Global.SkillData[skillId] as SkillItem;
                Type type = Type.GetType("MobaGame." + item.skillName);
                if(type != null)
                {
                    //改变技能列表对应的ID
                    skillIDList[index] = skillId;
                    //为角色挂上该技能脚本
                    gameObject.AddComponent(type);
                    BaseSkill skill = gameObject.GetComponent(type.ToString()) as BaseSkill;
                    skill.caster = this;
                    skill.attributes =  item;
					skill.reset ();
 
                }
            }
            //

        }

		public CommandManager GetCommandManager()
		{
			return m_cmdMgr;
		}

		//获取技能
        public void GetSkill(int index, ref BaseSkill skill)
        {
            int skillId = skillIDList[index];
            if (Global.SkillData.ContainsKey(skillId))
            {
                SkillItem item = Global.SkillData[skillId] as SkillItem;
                Type type = Type.GetType("MobaGame." + item.skillName);
                if(type != null)
                {
                    skill = gameObject.GetComponent(type.ToString()) as BaseSkill;
                }
            }
        }

		void OnBeginMove(object sender, EventArgs arg)
		{
			BeginMoveEvtArg e = arg as BeginMoveEvtArg;
			if(e.ac == this && state != ActorState.DEAD)
			{
				transform.LookAt (new Vector3 (e.position.x, transform.position.y, e.position.z));
				order = ActorOrder.MOVETO_ORDER;
				targetUnit = null;
				agent.SetDestination (e.position);
				SetState (new MovingActorState (this));
			}
		}

		void OnStopMove(object sender, EventArgs arg)
		{
			StopMoveEvtArg e = arg as StopMoveEvtArg;
			if(e.ac == this)
			{
				SetState (new IdleActorState (this));
			}

		}

		void OnDead(object sender, EventArgs arg)
		{
			UnitDieEvtArg e = arg as UnitDieEvtArg;
			if(e.deadUnit == this)
			{
				SetState (new DeadActorState (this));
			}
		}

		void OnBeginAttack(object sender, EventArgs arg)
		{
			BeginAttackEvtArg e = arg as BeginAttackEvtArg;
			if(this == e.ac)
			{
				if(e.target != null)
				{
					targetUnit = e.target.transform;
					agent.SetDestination (transform.position);
					SetState (new AttackActorState (this, e.target));
				}
			}
		}

		//移动到目的地
//		public void moveToOrder(Vector3 position)
//		{
//			if(state != ActorState.DEAD)
//			{
//				transform.LookAt (new Vector3 (position.x, transform.position.y, position.z));
//				order = ActorOrder.MOVETO_ORDER;
//				targetUnit = null;
//				agent.SetDestination (position);
//				state = ActorState.MOVING;
//			}
//		}
			

//		public void  AttackTargetOrder(Transform target)
//		{
//			if(state != ActorState.DEAD)
//			{
//				if (target == null)
//				{
//						throw new InvalidTransformException("target is Null!");
//				}
//				transform.LookAt (new Vector3 (target.position.x, transform.position.y, target.position.z));
//				Actor actor = target.gameObject.GetComponent<Actor> ();
//				//只有敌对阵营才使用攻击命令
//				if(actor != null && (actor.campType == CampType.E_CAMP_FREE || actor.campType != campType))
//				{
//					targetUnit = target;
//					//speed = 5.0f;
//					agent.SetDestination (targetUnit.position);
//					order = ActorOrder.ATTACK_ORDER;	
//				}else
//				{
//					moveToOrder (target.position);
//				}
//
//			}
//		}


		//对目标释放魔法
//		public void CastSpellToTargetOrder(Transform castTarget, int skillIndex)
//		{
//            if(state != ActorState.DEAD)
//            {
//                //这里设置使用当前技能槽的索引,更新状态时会做判断
//				if(castTarget)
//				{
//					transform.LookAt(new Vector3(castTarget.position.x, transform.position.y, castTarget.position.z));
//					agent.SetDestination (castTarget.position);	
//				}else{
//					return;
//				}
//				BaseSkill skill = null;
//				GetSkill(skillIndex, ref skill);
//				if(skill == null)
//				{
//					return;
//				}
//				if(skill.attributes.cost > mana)
//				{
//					Debug.Log (creatureName + "魔法值不够!");
//					return;
//				}
//				mana -= skill.attributes.cost;
//                curUseSkillIndex = skillIndex;
//				    
//                AnimationControlParamter paramter = GetAnimationParamter("CastSpell");
//                if(paramter != null)
//                {
//                    float AniTimeLen = GetAnimationLength("CastSpell");
//					Debug.Log ("施法动作长度" + AniTimeLen);
//					float time = skill.attributes.castTime;
//					if(time < Global.MinCastSpellTime)
//					{
//						time = Global.MinCastSpellTime;
//					}
//					paramter.timeScale = AniTimeLen / time;
//					SetAnimationParamter ("CastSpell",paramter);
//                }
//                else 
//                {
//                    Debug.Log("没找到CastSpell动画参数!");
//                }
//				skill.targetUnit = castTarget.GetComponent<Actor>();
//				if (!skill.VerifyAllowType ())
//					return;
//				skill.CastSkill(); 
//				order = ActorOrder.SPELLTO_ORDER;
//                
//            }
//			
//		}
//
//		public void CastSpellNoTarget (int skillIndex)
//		{
//			if (state != ActorState.DEAD) {
//				Debug.Log (creatureName + "使用了一个无目标的技能");
//				BaseSkill skill = null;
//				GetSkill(skillIndex, ref skill);
//				if(skill == null)
//				{
//					return;
//				}
//				if(skill.attributes.cost > mana)
//				{
//					Debug.Log (creatureName + "魔法值不够!");
//					return;
//				}
//				mana -= skill.attributes.cost;
//				curUseSkillIndex = skillIndex;
//
//				AnimationControlParamter paramter = GetAnimationParamter("CastSpell");
//				if(paramter != null)
//				{
//					float AniTimeLen = GetAnimationLength("CastSpell");
//					Debug.Log ("施法动作长度" + AniTimeLen);
//					float time = skill.attributes.castTime;
//					if(time < Global.MinCastSpellTime)
//					{
//						time = Global.MinCastSpellTime;
//					}
//					paramter.timeScale = AniTimeLen / time;
//					SetAnimationParamter ("CastSpell",paramter);
//				}
//				else 
//				{
//					Debug.Log("没找到CastSpell动画参数!");
//				}
//				if (!skill.VerifyAllowType ())
//					return;
//				skill.CastSkill ();
//				order = ActorOrder.SPELLTO_ORDER;
//			}
//
//		}

		public void CastSpellToPoint(Vector3 point, int skillIndex)
		{
			
			  
		}
 

		public ActorState GetState()
		{
			return state;
		}

		public Vector3 GetTargetPos()
		{
			return agent.destination;
		}
			
        //设置角色动画参数
        public void SetAnimationParamter(string animationName, AnimationControlParamter paramter)
        {
            //获取所有动画片段
            AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
            for (int i=0; i<clips.Length; i++)
            {
                if(clips[i].name == animationName)
                {
                    if(paramter.bLoop)
                    {
                        clips[i].wrapMode = WrapMode.Loop;
                        
                    }
                    else 
                    {
                        clips[i].wrapMode = WrapMode.Default;
                    }
                }
            }

            UnityEditor.Animations.AnimatorController ac = anim.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
            //获取状态机
            UnityEditor.Animations.AnimatorStateMachine asm = ac.layers[0].stateMachine;
            for(int i=0; i<asm.states.Length; i++)
            {
                UnityEditor.Animations.ChildAnimatorState cs = asm.states[i];
                if(cs.state.name == animationName)
                {
                    cs.state.speed = paramter.timeScale;
                    
                                      
                }
            }    
            
        }

        public float  GetAnimationLength(string  animationName)
        {
            float len = 0.0F;
            AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name == animationName)
                {
                    len = clips[i].length;
					Debug.Log ("动作名" + clips [i].name);
                    break;
                }
            }
            return len;

        }

        //获取角色动画参数
        public AnimationControlParamter GetAnimationParamter(string animationName)
        {      
            AnimationControlParamter paramter = new AnimationControlParamter();
            AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name == animationName)
                {
                    if (clips[i].wrapMode == WrapMode.Loop)
                    {
                        paramter.bLoop = true;
                        
                    }
                    else
                    {
                        paramter.bLoop = false;
                    }
                    break;
                }
            }

            UnityEditor.Animations.AnimatorController ac = anim.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
            //获取状态机
            UnityEditor.Animations.AnimatorStateMachine asm = ac.layers[0].stateMachine;
            for (int i = 0; i < asm.states.Length; i++)
            {
                UnityEditor.Animations.ChildAnimatorState cs = asm.states[i];
                if (cs.state.name == animationName)
                {
                    paramter.timeScale = cs.state.speed;
                    break;
                }
            }
            return paramter;
        }

		// Use this for initialization
		public void Start ()
		{
			 
			targetUnit = null;
            curUseSkillIndex = -1;
            curSkillSlot = -1;
			state = ActorState.IDLE;
			agent.updateRotation = true;
			loadAsset (assetName);
			SetState (new IdleActorState (this));
            //添加事件Handler
			BeginAttackHandler += OnBeginAttack;
			BeDamagedHandler += OnBeDamaged;
			RemoveBuffHandler += OnRemoveBuff;
			BeginMoveHandler += OnBeginMove;
			StopMoveHandler += OnStopMove;
			UnitDieHandler += OnDead;
			m_cmdMgr = new CommandManager ();
		 
            defaultAnimationParamters = new Hashtable();
            //将初始的动画参数保存为默认参数，以便修改后好还原
            AnimationClip[] clips =  anim.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++ )
            {
                AnimationControlParamter parameter = GetAnimationParamter(clips[i].name);
                defaultAnimationParamters[clips[i].name] = parameter;

            }
            //设置技能
            for(int i=0; i<skillIDList.Count; i++)
            {
                int skillId = skillIDList[i];
                if(Global.SkillData.ContainsKey(skillId))
                {
                    SetSkill(i, skillId);
                }
            }

			changeSpeed (speed);

		}   

		public void Update () {

			updateState ();  
		}

	 
		public void SetState(BaseActorState _state)
		{
			m_state = _state;
		}

		public ActorState GetCurState()
		{
			return m_state.GetState ();
		}

		void updateState()
		{
			m_state.Update ();
			//是否死亡
			mana += intelligence * Time.deltaTime;
			if(mana > maxMana)
			{
				mana = maxMana;
			}

		}

		void stopMove()
		{
			agent.SetDestination (transform.position);
			StopMoveEvtArg arg = new StopMoveEvtArg();
			arg.ac = this;
			FireEvent (this,EventType.EVT_STOP_MOVE,arg);
		}

 

		public void endAttack()
		{
			//Debug.LogWarning (creatureName + "攻击完成");
			BeDamageEvtArg arg = new BeDamageEvtArg ();
			arg.srcUnitID = transform.GetInstanceID ();
			if(targetUnit)
			{
				arg.srcUnitID = GetInstanceID ();
				arg.descUnitID = targetUnit.GetComponent<Actor>().GetInstanceID();
				arg.value = baseAttackDamage * (1 + strength * 0.02F);
				FireEvent (this, EventType.EVT_BE_DAMAGED, arg);
			}

		}

		public void beginSkillEffect()
		{
			if(curUseSkillIndex != -1)
			{
				BaseSkill skill = null;
				GetSkill(curUseSkillIndex, ref skill);
				skill.BeginSkillEffect ();
				SetState (new IdleActorState (this));
				//重置技能索引
				curUseSkillIndex = -1;

			}else
			{
				Debug.LogWarning ("当前使用技能索引无效!");
				
			}
		}
			
	}
}





