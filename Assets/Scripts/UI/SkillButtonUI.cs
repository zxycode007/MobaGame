using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MobaGame
{
    public class SkillButtonUI : MonoBehaviour
    {

        public Image imageButton;
        public Actor actor;
        public int index = 0;
        public Texture2D cursorTexture;
        // Use this for initialization
        
		public void SetActor(Actor ac)
		{
			actor = ac;
		}

        void Start()
        {

        }

        public void OnButtonDown()
        {
            Debug.Log("点击技能"+index+"按钮!");
            if(imageButton.fillAmount <= 0.1F)
            {
                actor.curSkillSlot = index;
				BaseSkill skill = null;
				actor.GetSkill (index, ref skill);
				if(skill != null)
				{
					CommandManager cmdMgr = actor.GetCommandManager ();

					switch(skill.attributes.targetType)
					{
					case SkillTargetType.Unit:
						{
							//设置鼠标光标
							Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
							//交由ActorControl去选择目标
							actor.SetCurUseSkillIndex (index);
							break;
						}
					case SkillTargetType.NoTarget:
						{
							cmdMgr.Clear ();
							cmdMgr.AddCommand (new SpellCastNoTargetCommand (actor, index));
							//actor.CastSpellNoTarget (actor.curSkillSlot);
							break;
						}
					}

				}
                
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Debug.Log("技能还没有准备好");
            }
        }

        // Update is called once per frame
        void Update()
        {
			actor = Global.GetActorManager ().GetPlayerActor ();
			if(actor != null)
			{
				if(index >= actor.skillIDList.Count)
				{
					return;
				}
				//更新技能CD效果
				int skillID = actor.skillIDList[index];
				if(Global.SkillData.Contains(skillID))
				{
					SkillItem it = Global.SkillData[skillID] as SkillItem;
					Type type = Type.GetType("MobaGame." + it.skillName);
					if (type != null)
					{

						BaseSkill skill = actor.GetComponent(type.ToString()) as BaseSkill;
						if (skill != null)
						{

							imageButton.fillAmount = (it.coolDownTime - skill.coolDownTimer) / it.coolDownTime;
							//Debug.Log("更新技能"+ index +"CD效果!"+ imageButton.fillAmount);

						}


					}

				}
			}

        }
    }
}

