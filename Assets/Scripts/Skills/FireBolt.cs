using UnityEngine;
using System.Collections;
using System;

namespace MobaGame
{
	public class FireBolt : BaseSkill
	{
		//投射模型
		public GameObject bolt;
		public GameObject HitEffect;


		public FireBolt()
		{
			
		}

		// Update is called once per frame
		void Update ()
		{
            BaseSkill parent = (BaseSkill)this;
            parent.Update();
        }

		void Start()
		{
			//BeginSkillEffect += OnBeginSkillEffect;
		}
	
		//开始技能效果
		public void OnBeginSkillEffect(object sender, EventArgs arg)
		{
			//Debug.LogWarning (caster.creatureName + "开始FireBolt技能效果");

			
		}
			

		public override void BeginSkillEffect()
		{
			Debug.LogWarning (caster.creatureName + "开始FireBolt技能效果");
			Debug.Log(caster.creatureName + "开始向" + targetUnit.creatureName + "释放技能");
			GameObject obj = Global.GetPrefab ("FireBolt");
			if (obj != null)
			{
				bolt = Instantiate(obj, caster.transform.position, caster.transform.rotation) as GameObject;
				bolt.transform.LookAt(targetUnit.transform.position);
				bolt.GetComponent<FireBoltEffect>().caster = caster;
				bolt.GetComponent<FireBoltEffect>().target = targetUnit;
				bolt.GetComponent<FireBoltEffect>().bolt = this;
			}
		}

		public override bool VerifyAllowType ()
		{ 
			string msg = "";
			bool ret = false;
			if (targetUnit != null)
			{
				//首先阵营不一样
				if((targetUnit.campType != caster.campType || targetUnit.campType != CampType.E_CAMP_FREE) && targetUnit.state != ActorState.DEAD)
				{
					ret = true;
				}
				
			}else{
				msg = "targetUnit is Null!";
				throw new InvalidUnitException(msg);
			}
			return ret;
		}

	}
}



