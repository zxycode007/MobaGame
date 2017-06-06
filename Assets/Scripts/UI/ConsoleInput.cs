using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MobaGame
{
	public class ConsoleInput : MonoBehaviour {

		public InputField inputField;
		string inputMsg;

		void Start () {
 

		}


		public void GetInput()
		{
			inputMsg = inputField.text;
			Global.Println (inputMsg);
			inputField.text = "";
			 
		}

		// Update is called once per frame
		void Update () {


		 

		}

		 


		 
	}
}


