using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace MobaGame
{
    [Serializable]
    public class SkillItem : ScriptableObject
    {
        public string skillName = "未命名技能";
        public int skillID = 1;
        public SkillTargetType targetType = SkillTargetType.NoTarget;
        public bool isPositive = true;
        public float coolDownTime = 0;    //冷却时间
        public float radius = 0;
        public float castDistance = 0;   //施放距离
        public float castTime = 0;     //施法时间
        public float duration = 0;       //持续施法时间
        public float cost = 0;            //魔法消耗



    }
}
