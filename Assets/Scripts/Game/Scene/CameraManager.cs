using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class CameraManager : GameContext
	{
		Camera m_mainCam;
		Transform m_followTarget;
		public Vector3    camRelativePos;

		void Start ()
		{
			m_mainCam = Camera.main;
		}

		public void SetFollowTarget(Transform target)
		{
			m_followTarget = target;
		}


		// Update is called once per frame
		void Update ()
		{
			if(m_followTarget != null)
			{
				Vector3 pos = m_followTarget.position;
				Camera.main.transform.position = pos + camRelativePos;
				Camera.main.transform.LookAt (m_followTarget);
			}

		}
	}
}



