using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

namespace MobaGame
{
	public class GameState : BaseSceneState
	{

		public GameState(SceneController controller):base(controller)
		{
			this.m_sceneName = "GameScene";
			this.m_eState = ESceneState.E_SCENE_STATE_GAME;
			SceneManager.sceneLoaded += OnSceneLoaded;
		
		}

		public override void SceneStateBegin()
		{
			m_bRunState = true;
			GameContext.MouseFire1Handler += OnMouseFire1;
			GameContext.MouseFire2Handler += OnMouseFire2;
			 
		}

		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if(scene.name == m_sceneName)
			{
				Debug.Log ("场景加载完成!");
				m_bIsLoaded = true;
			}
		}

		public override void SceneStateEnd()
		{

		}

		void OnMouseFire1(object sender, EventArgs arg)
		{
			//Debug.Log ("鼠标点击1");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 200))
			{
				Actor player =  Global.GetActorManager().GetPlayerActor();
				Actor targetUnit = hit.transform.GetComponent<Actor> ();
				if(hit.transform.tag == "assailable" && player.GetCurUseSkillIndex() != -1 && targetUnit != null)
				{
					
					CommandManager cmdMgr =  player.GetCommandManager();
					cmdMgr.Clear();
					cmdMgr.AddCommand (new SpellCastToTargetUnit (player,targetUnit, player.GetCurUseSkillIndex ()));
					 
				}else
				{
					player.SetCurUseSkillIndex (-1);
				}
			}
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}

		void OnMouseFire2(object sender, EventArgs arg)
		{
			Debug.Log ("鼠标点击2");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 200))
			{
				Vector3 pos = hit.point;
				Actor player =  Global.GetActorManager().GetPlayerActor();
				CommandManager cmdMgr =  player.GetCommandManager();
				cmdMgr.Clear();
				if(hit.transform.tag == "Terrian")
				{
					//点击地面                  
                    cmdMgr.AddCommand(new MoveToCommand(pos, player));
				}else if(hit.transform.tag == "assailable")
				{
					//可攻击的目标
                    cmdMgr.AddCommand(new AttackCommand(hit.transform.GetComponent<Actor>(), player));

				}
				Vector3 screenPos = Camera.main.WorldToScreenPoint (pos);
				//NavigatorIcon.transform.position = screenPos;
				//NavigatorIcon.enabled = true;
			}
		}

		public override void SceneStateUpdate()
		{
			//Debug.Log ("GameState Update！");
		}
	}
}



