using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace MobaGame
{
	public class PlayerUI : GameContext {

		//UI状态列表
		public Dictionary<int,GameObject> buffIconMap;
		public Actor  player;
		public GameObject lifeBar;
		public GameObject magicBar;
		private bool  isDirty;
		// Use this for initialization
		void Start () {
			
			buffIconMap = new Dictionary<int,GameObject> ();
			isDirty = false;
			AddBuffHandler += OnAddBuff;
			RemoveBuffIconHandler += OnRemoveBuff;
		}
		public void SetActor(Actor ac)
		{
			player = ac;
		}
		// Update is called once per frame
		void Update () {
			
			gameObject.SetActive (true);
			player = Global.GetActorManager ().GetPlayerActor ();
			if(isDirty)
			{
				List<int> deleteList = new List<int> ();
				//重新更新UI
				int posx = 10;
				int posY = -60;
				foreach(KeyValuePair<int,GameObject> pair in buffIconMap)
				{
					GameObject imgObj = pair.Value;
					//设置子节点，重新排列位置
					Image img = imgObj.GetComponent<Image> ();
					img.transform.SetParent(this.transform);
					Vector3 imgPos = new Vector3 (posx, posY, 0);
					img.transform.localPosition = imgPos;
					img.enabled = true;
					posx += 28;
				}
				isDirty = false;
			}
			if(player != null)
			{
				lifeBar.GetComponent<Image>().fillAmount = player.life / player.maxLife;
				magicBar.GetComponent<Image>().fillAmount = player.mana / player.maxMana;

			}


		}
				 

		void OnAddBuff(object sender, EventArgs arg)
		{
			
			AddBuffEvtArg _arg = arg as AddBuffEvtArg;
			int buffID = _arg.buffID;
			if(Global.BuffData.ContainsKey(buffID))
			{
				BuffItem buff = Global.BuffData [buffID] as BuffItem;
				Debug.Log ("buff icon = " + buff.iconName);
				if(buffIconMap.ContainsKey(buff.BuffID))
				{
					return;
				}
				GameObject obj = Global.GetPrefab (buff.iconName);
				if(obj == null)
				{
					Debug.LogWarning ("未能读取到" + buff.iconName);
					return;
				}
					
				Debug.Log (obj.name);
				GameObject imgObj = (GameObject)Instantiate(obj);
				Image img = obj.GetComponent<Image> ();
				img.enabled = false;
				buffIconMap.Add (buffID, imgObj);
				isDirty = true;	

			}else
			{
				Debug.Log ("OnAddBuff失败！没找到Buff");
			}
		}

		void OnRemoveBuff(object sender, EventArgs arg)
		{
			isDirty = true;
			RemoveBuffIconEvtArg e = arg as RemoveBuffIconEvtArg;
			if(buffIconMap.ContainsKey(e.buffID))
			{
				GameObject imgObj = buffIconMap [e.buffID];
				Image img = imgObj.GetComponent<Image> ();
				img.enabled = false;
				Destroy (imgObj);
				buffIconMap.Remove (e.buffID);
			}
		}
	}
}
