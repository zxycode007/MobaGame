﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MobaGame
{
	public class ConsoleUI : MonoBehaviour {

		public Scrollbar bar;

		// Use this for initialization
		void Start () {

		}


		// Update is called once per frame
		void Update () {

		}

		public void UpdateScrollBar()
		{
			bar.value = 0;
		}

		void OnGUI()
		{
			 
		}
	}
}

