using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;


namespace MobaGame
{
	public enum SkillTargetType
	{
		NoTarget,
		Point,
		Unit,
		Area
	}

	 
	
	public abstract class BaseSkill: GameContext {

		public Actor caster;
        public Actor targetUnit;  //目标单位
        public Vector3 targetPos;    //目标点
		public string skillAssetName;
		public SkillItem attributes;
		public float timeScale;            //施法速度时间缩放
		public float coolDownTimer;
		public float castTimer;
		public float durationTimer;

        void Start()
        {
			
        }

		public void reset()
		{
			castTimer = attributes.castTime;
			coolDownTimer = attributes.coolDownTime;
			timeScale = 1.0F;
			durationTimer = attributes.duration;
		}

         public void Update()
        {
            //更新计时器
            if (coolDownTimer < attributes.coolDownTime)
            {
                coolDownTimer += Time.deltaTime;
				//Debug.Log ("技能冷却中:" + coolDownTimer);
            }
            else
            {
                coolDownTimer = attributes.coolDownTime;
            }
            
                  
            //Debug.Log("更新计时器"+castTimer.ToString());
        }

        //正在释放技能   
		public  void  CastSkill ()
		{
			//开始释放技能，CD开始计时
			if(attributes.coolDownTime - coolDownTimer <= 0.1F)
			{              
				coolDownTimer = 0;
			}
			else
			{
				//被否决不能释放技能
			}
			Debug.Log("技能释放!");
			caster.curSkillSlot = -1;
		}

		//验证运行类型
		public abstract bool VerifyAllowType ();


		public abstract  void  BeginSkillEffect ();

	}
}

