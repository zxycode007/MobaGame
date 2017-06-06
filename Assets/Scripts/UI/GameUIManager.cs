using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class GameUIManager : GameContext
	{
		GameObject m_playerPortrait;
		GameObject m_LifeBar;
		GameObject m_MagicBar;
		GameObject m_SkillButtonSlot1;
		GameObject m_SkillButtonSlot2;
		GameObject m_SkillButtonSlot3;
		GameObject m_SkillButtonSlot4;
		GameObject m_SkillButtonSlot5;

		// Use this for initialization
		void Start ()
		{
			m_playerPortrait = GameObject.Find ("PlayerPortrait");
			m_LifeBar = GameObject.Find ("LifeBar");
			m_MagicBar = GameObject.Find ("MagicBar");
			m_SkillButtonSlot1 = GameObject.Find ("SkillButtonSlot1");
			m_SkillButtonSlot2 = GameObject.Find ("SkillButtonSlot2");
			m_SkillButtonSlot3 = GameObject.Find ("SkillButtonSlot3");
			m_SkillButtonSlot4 = GameObject.Find ("SkillButtonSlot4");
			m_SkillButtonSlot5 = GameObject.Find ("SkillButtonSlot5");
		}

		// Update is called once per frame
		void Update ()
		{
//			if(Global.GetActorManager().GetPlayerActor() == null)
//			{
//				m_playerPortrait.SetActive (false);
//				m_LifeBar.SetActive (false);
//				m_MagicBar.SetActive (false);
//				m_SkillButtonSlot1.SetActive (false);
//				m_SkillButtonSlot2.SetActive (false);
//				m_SkillButtonSlot3.SetActive (false);
//				m_SkillButtonSlot4.SetActive (false);
//				m_SkillButtonSlot5.SetActive (false);
//			}else
//			{
//				m_playerPortrait.SetActive (true);
//				m_LifeBar.SetActive (true);
//				m_MagicBar.SetActive (true);
//				m_SkillButtonSlot1.SetActive (true);
//				m_SkillButtonSlot2.SetActive (true);
//				m_SkillButtonSlot3.SetActive (true);
//				m_SkillButtonSlot4.SetActive (true);
//				m_SkillButtonSlot5.SetActive (true);
//			}
		}
	}
}



