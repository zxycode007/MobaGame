using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class BaseCommand : object
	{
		protected string m_commandName;
		protected bool m_bFinished;
		protected bool m_isRunning;

		public BaseCommand()
		{
			m_commandName = "BaseCommand";
			m_bFinished = false;
			m_isRunning = false;
		}

		public bool isRunning()
		{
			return m_isRunning;
		}

		public virtual void run()
		{
			return;
		}

		public virtual void update()
		{
			
		}

		public virtual bool isFinished()
		{
			return m_bFinished;
		}
		 
	}
}


