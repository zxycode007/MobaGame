using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class SpellCastNoTargetCommand : BaseCommand {

		Actor m_caster;
		int m_skillIndex;

		public SpellCastNoTargetCommand(Actor caster, int skillIndex)
		{
			m_commandName = "SpellCastNoTarget";
			m_caster = caster;
			m_skillIndex = skillIndex;
		}

		public override void run()
		{
			if (m_caster.GetState() != ActorState.DEAD) {
				Debug.Log (m_caster.creatureName + "使用了一个无目标的技能");
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
				m_caster.SetCurUseSkillIndex(m_skillIndex);

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
				if (!skill.VerifyAllowType ())
					return;
				skill.CastSkill ();
				m_caster.SetState (new CastSpellActorState (m_caster));
			}
			this.m_isRunning = true;
		}

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

