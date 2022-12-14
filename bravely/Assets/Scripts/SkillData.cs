using Data.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    // Common namespace
    namespace Skill
    {
        public abstract class SkillData : ScriptableObject
        {
            protected string title;
            protected string description;
            
            protected float cost;
            protected float damage;
            protected float coolTime;
            protected float distance;
            protected float range;
            protected float delay;
        }
    }



    namespace LongSword
    {

        [CreateAssetMenu(fileName = "LongSwordSkillData1",
                         menuName = "Scriptable Object/LongSwordSkillData1",
                         order = int.MaxValue)]
        public class SkillData1 : SkillData
        {

        }

        [CreateAssetMenu(fileName = "LongSwordSkillData2",
                         menuName = "Scriptable Object/LongSwordSkillData2",
                         order = int.MaxValue)]
        public class SkillData2 : SkillData
        {
            
        }

        [CreateAssetMenu(fileName = "LongSwordSkillData3",
                         menuName = "Scriptable Object/LongSwordSkillData3",
                         order = int.MaxValue)]
        public class SkillData3 : SkillData
        {

        }

        [CreateAssetMenu(fileName = "LongSwordSkillData4",
                         menuName = "Scriptable Object/LongSwordSkillData4",
                         order = int.MaxValue)]
        public class SkillData4 : SkillData
        {

        }
    }
}
