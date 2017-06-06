using UnityEngine;
using System.Collections;
using System;

namespace MobaGame
{
	[Serializable]
	public class InvalidTransformException : ApplicationException
	{

		public InvalidTransformException()
		{
			
		}

		public InvalidTransformException(string msg) :base(msg)
		{

		}

		public InvalidTransformException(string msg, Exception inner): base(msg, inner)
		{

		}
	}
}


