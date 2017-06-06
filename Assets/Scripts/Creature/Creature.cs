using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables;

namespace MobaGame
{
	public enum CreatureType 
	{
		HUMAN = 0,
		MECHANICAL = 1,
		DRAGON = 2,
		UNDEAD = 4,
		GOD = 8

	}

	public enum CampType
	{
		E_CAMP_RED,
		E_CAMP_BLUE,
		E_CAMP_MONSTER,
		E_CAMP_NPC,
		E_CAMP_FREE
	}
	
	
	public class Creature : GameContext {
		 
		public string creatureName = "newCreature";
		public float  life = 100;
		public float  maxLife = 100;
		public float  mana = 100;
		public float  maxMana = 100;
		public float  stamina = 100;
		public float  maxStamina = 100;
		public int    level = 1;
		public float  speed = 1;
		public float  attackSpeed = 1;
		public float  attackRange = 1;
		public float  baseAttackDamage = 20;
		public float  strength = 5;             
		public float  intelligence = 5;
		public float  agile = 5;
		public float  armorClass = 0;
		public float  magicResistance = 0;
		public float  elementResistance = 0;
		public float  shadowResistance = 0;
		public float  magicPower = 0;
		public float  spellCastSpeed = 1;
		public float  criticalStrikeRate = 0;
		public float  magicCriticalStrikeRate = 0;
		public CampType campType = CampType.E_CAMP_FREE;
        public List<int> skillIDList = new List<int>();
		public CreatureType type = CreatureType.HUMAN;
		//默认数据以便还原
		public CreatureItem defaultData;
		//Buff表
		public SortedDictionary<int, List<BaseBuff>> buffMap;

		public void Start()
		{
			
		}

		public void Update()
		{
			 
		}

		public void OnRemoveBuff(object sender, EventArgs arg)
		{
			RemoveBuffEvtArg e = arg as RemoveBuffEvtArg;
			int buffId = e.buffID;
			int casterId = e.casterID;
			int ownerId = e.ownerID;
			int count = e.count;
			if(ownerId ==  gameObject.GetComponent<Actor>().GetInstanceID())
			{
				Debug.Log (name + "移除buff ， buff ID = " + buffId);
				RemoveBuff (buffId, count);			
			}

		}

		public void OnBeDamaged(object sender, EventArgs arg)
		{

			BeDamageEvtArg e = arg as BeDamageEvtArg;
			if(GetInstanceID() != e.descUnitID)
			{
				return;
			}
			life -= e.value;
			GameObject obj = EditorUtility.InstanceIDToObject (e.srcUnitID) as GameObject;
			string attackName = "";
			if(obj)
			{
				attackName = obj.name;
			}
			//Debug.Log ("遭受到来自"+attackName+"的"+e.value+"点伤害");
			Global.Println ("遭受到来自" + attackName + "的" + e.value + "点伤害");
			if(life <= 0)
			{
				UnitDieEvtArg ueArg = new UnitDieEvtArg ();
				ueArg.deadUnitID = GetInstanceID();
				ueArg.murdererID = e.srcUnitID;
				ueArg.deadUnit = this.gameObject.GetComponent<Actor> ();
				if(obj!=null)
				{
					ueArg.killerUnit = obj.gameObject.GetComponent<Actor> ();
				}
				FireEvent (this, EventType.EVT_UNIT_DIE, ueArg);
			}


		}

		public void OnBeAttacked(object sender, EventArgs arg)
		{
			BeginAttackEvtArg e = arg as BeginAttackEvtArg;
			Transform attacker = EditorUtility.InstanceIDToObject (e.attackerID) as Transform;
			Transform sufferer = EditorUtility.InstanceIDToObject (e.targetID) as Transform;
			if(attacker)
			{
				Actor ac = attacker.GetComponent<Actor> ();
				//Debug.Log (ac.creatureName + "开始攻击！");
			}
			if(sufferer)
			{
				Actor ac = sufferer.GetComponent<Actor> ();
				//Debug.Log (ac.creatureName + "正在遭受攻击！");
			}

		}

		//添加buff
		public void AddBuff(BaseBuff buff)
		{
			int buffID = buff.attributes.BuffID;
			Debug.Log ("BuffID=" + buffID);
			//没有这个buff组，创建一个
			if(buffMap.ContainsKey(buffID) == false)
			{
				buffMap [buffID] = new List<BaseBuff> ();
			}
			//判断是否允许叠加, 必须最大层数
			if(buff.attributes.allowOverlay == true && buffMap[buffID].Count < buff.attributes.count)
			{
				buffMap[buffID].Add(buff);
				buff.OnAddBuff ();
				AddBuffEvtArg arg = new AddBuffEvtArg ();
				arg.buffID = buffID;
				arg.casterID = buff.caster.GetInstanceID ();
				arg.ownerID = buff.Owner.GetInstanceID ();
				FireEvent (this, EventType.EVT_ADD_BUFF, arg);

			}else
			{   
				buffMap [buffID].Clear ();
				buffMap [buffID].Add (buff);
				buff.OnAddBuff ();
				AddBuffEvtArg arg = new AddBuffEvtArg ();
				arg.buffID = buffID;
				arg.casterID = buff.caster.GetInstanceID ();
				arg.ownerID = buff.Owner.GetInstanceID ();
				FireEvent (this, EventType.EVT_ADD_BUFF, arg);
			}

		}
		//移除buff
		public void RemoveBuff(int buffID, int count)
		{
			if(!buffMap.ContainsKey(buffID))
			{
				//没有此buff，不用移除
				return;
			}
			if(Global.BuffData.ContainsKey(buffID) == false)
			{
				return;
			}
			BuffItem buffItem = Global.BuffData [buffID] as BuffItem;
			if(buffItem.canBeRemoved == true)
			{
				//移除指定数量
				if(buffMap.ContainsKey(buffID))
				{
					for(int i=buffMap[buffID].Count-1; i>=0; i--)
					{
						BaseBuff buff = buffMap [buffID] [i];
						buff.OnRemoveBuff ();
						buffMap [buffID].Remove (buff);
					}
				}
			}
			//判断是否为玩家单位
			if(Global.GetPlayer() == gameObject)
			{
				if(!buffMap.ContainsKey(buffID) || buffMap[buffID].Count==0 )
				{
					RemoveBuffIconEvtArg arg = new RemoveBuffIconEvtArg ();
					arg.buffID = buffID;
					FireEvent (this,EventType.EVT_REMOVE_BUFF_ICON, arg);
				}
			}

		}

		public void unitDie()
		{
			transform.gameObject.SetActive (false);
			//BehaviorManager behaviorMgr =  gameObject.GetComponent<BehaviorManager> ();
			//behaviorMgr.enabled = false;
		}

		public void Load(string path)
		{
			CreatureItem creatureData = AssetDatabase.LoadAssetAtPath<CreatureItem> (path);
			defaultData = creatureData;
			creatureName = creatureData.creatureName;
			life = creatureData.life;
			maxLife = creatureData.maxLife;
			mana = creatureData.mana;
			maxMana = creatureData.maxMana;
			stamina = creatureData.stamina;
			maxStamina = creatureData.maxStamina;
			level = creatureData.level;
			speed = creatureData.speed;
			attackSpeed = creatureData.attackSpeed;
			attackRange = creatureData.attackRange;
			baseAttackDamage = creatureData.baseAttackDamage;
			strength = creatureData.strength;
			intelligence = creatureData.intelligence;
			agile = creatureData.agile;
			armorClass = creatureData.armorClass;
			magicResistance = creatureData.magicResistance;
			elementResistance = creatureData.elementResistance;
			shadowResistance = creatureData.shadowResistance;
			magicPower = creatureData.magicPower;
			criticalStrikeRate = creatureData.criticalStrikeRate;
			magicCriticalStrikeRate = creatureData.magicCriticalStrikeRate;
            skillIDList = creatureData.skillIDList;
			type = creatureData.type;
			buffMap = new SortedDictionary<int, List<BaseBuff>> ();
				
		}

		//生物属性复位
		public void reset()
		{
			creatureName = defaultData.creatureName;
			life = defaultData.life;
			maxLife = defaultData.maxLife;
			mana = defaultData.mana;
			maxMana = defaultData.maxMana;
			stamina = defaultData.stamina;
			maxStamina = defaultData.maxStamina;
			level = defaultData.level;
			speed = defaultData.speed;
			attackSpeed = defaultData.attackSpeed;
			attackRange = defaultData.attackRange;
			baseAttackDamage = defaultData.baseAttackDamage;
			strength = defaultData.strength;
			intelligence = defaultData.intelligence;
			agile = defaultData.agile;
			armorClass = defaultData.armorClass;
			magicResistance = defaultData.magicResistance;
			elementResistance = defaultData.elementResistance;;
			shadowResistance = defaultData.shadowResistance;
			magicPower = defaultData.magicPower;
			criticalStrikeRate = defaultData.criticalStrikeRate;
			magicCriticalStrikeRate = defaultData.magicCriticalStrikeRate;
			skillIDList = defaultData.skillIDList;
			type = defaultData.type;
			buffMap.Clear ();
		}

	}
}


