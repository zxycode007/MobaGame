using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class SpellCastToTargetUnit : BaseCommand {

		Actor m_caster;
		Actor m_targetUnit;
		int m_skillIndex;
		public SpellCastToTargetUnit(Actor player, Actor targetUnit, int index)
		{
			m_commandName = "SpellCastToTargetUnit";
			m_caster = player;
			m_targetUnit = targetUnit;
			m_skillIndex = index;

		}
		public override void run()
		{
			if(m_caster.GetState() != ActorState.DEAD)
			{
				//这里设置使用当前技能槽的索引,更新状态时会做判断
				if(m_targetUnit != null)
				{
					m_caster.transform.LookAt(new Vector3(m_targetUnit.transform.position.x, m_caster.transform.position.y, m_targetUnit.transform.position.z));
					m_caster.agent.SetDestination (m_targetUnit.transform.position);	
				}else{
					return;
				}
				BaseSkill skill = null;
				m_caster.GetSkill(m_skillIndex, ref skill);
				if(skill == null)
				{
					return;
				}
				if(skill.attributes.cost > m_caster.mana)
				{
					Debug.Log (m_caster.creatureName + "魔法值不够!");
					return;
				}
				m_caster.mana -= skill.attributes.cost;
				m_caster.SetCurUseSkillIndex (m_skillIndex);

				AnimationControlParamter paramter = m_caster.GetAnimationParamter("CastSpell");
				if(paramter != null)
				{
					float AniTimeLen = m_caster.GetAnimationLength("CastSpell");
					Debug.Log ("施法动作长度" + AniTimeLen);
					float time = skill.attributes.castTime;
					if(time < Global.MinCastSpellTime)
					{
						time = Global.MinCastSpellTime;
					}
					paramter.timeScale = AniTimeLen / time;
					m_caster.SetAnimationParamter ("CastSpell",paramter);
				}
				else 
				{
					Debug.Log("没找到CastSpell动画参数!");
				}
				skill.targetUnit = m_targetUnit.GetComponent<Actor>();
				if (!skill.VerifyAllowType ())
					return;
				skill.CastSkill(); 
				m_caster.SetState (new CastSpellActorState (m_caster));

			}
			m_isRunning = true;
		}

		// Update is called once per frame
		public override void update()
		{
			if(!m_isRunning)
			{
				run ();
			}
			m_bFinished = true;

		}
	}
}

