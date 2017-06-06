using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	//表示可以序列化
	[Serializable]
	public class CreatureItem : ScriptableObject {

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
		public float  baseAttackDamage = 100;
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
        public List<int> skillIDList = new List<int>();
        public CreatureType type = CreatureType.HUMAN;

	}
}

