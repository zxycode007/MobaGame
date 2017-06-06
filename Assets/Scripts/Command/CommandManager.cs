using UnityEngine;
using System.Collections;


namespace MobaGame
{
	public class CommandManager : object
	{
		Queue m_commandQueue;
		// Use this for initialization
		public CommandManager ()
		{
			m_commandQueue = new Queue ();
		}

		public void AddCommand(BaseCommand cmd)
		{
			m_commandQueue.Enqueue (cmd);
		}

		public void Clear()
		{
			m_commandQueue.Clear ();
		}

		// Update is called once per frame
		public void Update ()
		{
			
			if(m_commandQueue.Count > 0)
			{
				BaseCommand cmd = m_commandQueue.Peek () as BaseCommand;
				if(cmd == null || cmd.isFinished())
				{
					m_commandQueue.Dequeue ();
					return;
				}
				cmd.update ();
			}


		}
	}
}



