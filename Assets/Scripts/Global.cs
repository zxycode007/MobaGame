using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace MobaGame
{
	
	public class Global   {

		public static readonly float MaxUnitSpeed = 522f;
		public static readonly float MinUnitSpeed = 1.0F;
		public static readonly float CloseDistance = 1.0F;
		public static readonly float MinCastSpellTime = 0.3F;
		public static readonly float MinUnitDistance = 1.0F;
		public static readonly Hashtable SkillData;
		public static readonly Hashtable globalDataTable;
		public static readonly Hashtable BuffData;
		static GameObject playerObj;
		static TimerManager timerManager;
		static GameObject consoleWnd;
		static GameLoop gameManager;
		static GameObject m_spawnPointA;
		static GameObject m_spawnPointB;
		static ActorManager actorManager;
		static CameraManager m_cameraManager;
		static GameUIManager m_uiManager;
		//预置表
		public static Dictionary<string, GameObject> prefabData;

		static Global()
		{
			Debug.Log("全局初始化");
			Debug.LogWarning("初始化系统!");
			SkillData = new Hashtable();
			BuffData = new Hashtable ();
			globalDataTable = new Hashtable ();
			prefabData = new Dictionary<string,GameObject>();
			string path = Application.dataPath + "/Resource/Data/Skill/";
			ReadSkillData(path);
			path = Application.dataPath + "/Resource/Data/Buff/";
			ReadBuffData (path);
			path = Application.dataPath + "/Resources/";
			ReadPrefabs (path);
			path = Application.dataPath + "/Resources/Textures";
			ReadPrefabs (path);
			path = Application.dataPath + "/Resources/UI";
			ReadPrefabs (path);
		}

		public static ActorManager GetActorManager()
		{
			if(actorManager == null)
			{
				GameObject obj = GameObject.Find ("GameManager");
				if(obj != null)
				{
					actorManager = obj.GetComponent<ActorManager> ();
				}
			}
			return actorManager;
		}

		public static GameUIManager GetUIManager()
		{
			if(m_uiManager == null)
			{
				GameObject obj = GameObject.Find ("GameManager");
				if(obj != null)
				{
					m_uiManager = obj.GetComponent<GameUIManager> ();
				}
			}
			return m_uiManager;
		}

		public static GameObject GetSpawnPointA()
		{
			if(m_spawnPointA == null)
			{
				m_spawnPointA = GameObject.Find ("SpawnPointA");
			}
			return m_spawnPointA;
		}

		public static GameObject GetSpawnPointB()
		{
			if(m_spawnPointB == null)
			{
				m_spawnPointB = GameObject.Find ("SpawnPointB");
			}
			return m_spawnPointB;
		}

		public static CameraManager GetCameraManager()
		{
			if(m_cameraManager == null)
			{
				m_cameraManager =  Camera.main.gameObject.GetComponent<CameraManager> ();
			}
			return m_cameraManager;
		}

		   
		//获取玩家单位
		public static GameObject GetPlayer()
		{
			if(playerObj == null)
			{
				playerObj = GameObject.Find ("player");
			}
			return playerObj;
		}

		public static GameObject GetConsole()
		{
			if(consoleWnd == null)
			{
				consoleWnd = GameObject.Find ("ConsolePanel");
			}
			return consoleWnd;
		}

		public static void Println(string msg)
		{
			GetConsole ();
			if(consoleWnd != null)
			{
				GameObject console = GameObject.Find ("ConsolePanel/ConsoleOutput");
				Text output = console.GetComponent<Text>();
				output.text += msg;
				output.text += "\n";

			}
		}

		public static TimerManager GetTimerManager()
		{
			if(timerManager==null)
			{
				GameObject obj = GameObject.Find ("GameManager");
				if(obj != null)
				{
					timerManager = obj.GetComponent<TimerManager> ();
				}
			}
			return timerManager;
		}

		public static GameLoop GetGameManager()
		{
			if(gameManager==null)
			{
				GameObject obj = GameObject.Find ("GameManager");
				if(obj != null)
				{
					gameManager = obj.GetComponent<GameLoop> ();
				}
			}
			return gameManager;
		}

		public static GameObject GetPrefab(string name)
		{
			if(prefabData.ContainsKey(name))
			{
				return prefabData [name];
			}
			return null;
		}

        //变量
        static void ReadSkillData(string dirPath)
        {
            Debug.Log("读取" + dirPath + "目录");
            foreach(string path in Directory.GetFiles(dirPath))
            {
                if(System.IO.Path.GetExtension(path) == ".asset")
                {
                    string skillResourcePath = "Assets/Resource/Data/Skill/" + System.IO.Path.GetFileName(path);
                    Debug.Log("读取"+skillResourcePath);
                    SkillItem item = AssetDatabase.LoadAssetAtPath<SkillItem>(skillResourcePath);
                    if(item != null)
                    {
                        SkillData.Add(item.skillID, item);
                    }
                    else
                    {
                        Debug.Log("读取" + skillResourcePath + "失败");
                    }
                }
            }
        }

		static void ReadBuffData(string dirPath)
		{
			Debug.Log("读取" + dirPath + "目录");
			foreach(string path in Directory.GetFiles(dirPath))
			{
				if(System.IO.Path.GetExtension(path) == ".asset")
				{
					string buffResourcePath = "Assets/Resource/Data/Buff/" + System.IO.Path.GetFileName(path);
					Debug.Log("读取"+buffResourcePath);
					BuffItem item = AssetDatabase.LoadAssetAtPath<BuffItem>(buffResourcePath);
					if(item != null)
					{
						BuffData.Add(item.BuffID, item);
					}
					else
					{
						Debug.Log("读取" + buffResourcePath + "失败");
					}
				}
			}
		}

		static void ReadPrefabs(string dirPath)
		{
			Debug.Log("读取" + dirPath + "目录");
			foreach(string path in Directory.GetFiles(dirPath))
			{
				//只取文件名
				string fileName =  System.IO.Path.GetFileNameWithoutExtension(path);
				int index = path.IndexOf ("Assets");
				string fileRePath = path.Substring (index);
				GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(fileRePath) as GameObject; 
				if (obj != null)
				{
					//添加到预置表选中
					prefabData.Add (fileName, obj);
					Debug.Log ("读取" + fileName + "到预置表中");
				}
			}
			 

		}



        //初始化的时候调用
//        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//        public static void Init()
//        {
//           
//        }
	}
}

