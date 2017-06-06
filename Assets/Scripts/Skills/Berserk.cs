using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class Berserk : BaseSkill {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			BaseSkill parent = (BaseSkill)this;
			parent.Update();
		}
			
		public void endEffect(Hashtable table)
		{
			
			RemoveBuffEvtArg arg = new RemoveBuffEvtArg ();
			arg.buffID = (int)table ["BuffID"];
			arg.casterID = (table["Caster"] as Actor).GetInstanceID();
			arg.ownerID = (table["Owner"] as Actor).GetInstanceID();
			arg.count = 1;
			Debug.Log ("结束Berserk效果事件");
			FireEvent (this, EventType.EVT_REMOVE_BUFF, arg);
		}

		public override void BeginSkillEffect()
		{
			Debug.LogWarning (caster.creatureName + "开始Berserk技能效果");
			BerserkBuff buf = new BerserkBuff ();
			buf.attributes = Global.BuffData [1] as BuffItem;
			buf.caster = caster;
			buf.Owner = caster;
			buf.period = 1.0F;
			buf.timer = 0.0F;

			caster.AddBuff (buf);
			System.Action<Hashtable> action = new System.Action<Hashtable> (endEffect);
			Hashtable table = new Hashtable ();
			table.Add ("Caster", caster);
			table.Add ("Owner", caster);
			table.Add ("BuffID", buf.attributes.BuffID);

			TimerManager tm = Global.GetTimerManager ();
			if(tm != null)
			{
				Timer t = tm.createNewTimer (attributes.duration, false, action, table);
				tm.AddTimer (t);
			}else
			{
				Debug.LogError ("访问TimerManager失败!");
			}
			Debug.Log ("添加Berserk效果");
		}


		public override bool VerifyAllowType ()
		{ 
			string msg = "";
			bool ret = false;
			if (caster != null)
			{
				if(caster.state != ActorState.DEAD)
				{
					ret = true;
				}

			}else{
				msg = "Caster is Null!";
				throw new InvalidUnitException(msg);
			}
			return ret;
		}
	}
}

