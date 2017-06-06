using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MobaGame
{
	[Serializable]
	public class InvalidUnitException : ApplicationException {

		public InvalidUnitException()
		{}

		public InvalidUnitException(string msg) :base(msg)
		{
			
		}

		public InvalidUnitException(string msg, Exception inner): base(msg, inner)
		{
			
		}
	}
}

