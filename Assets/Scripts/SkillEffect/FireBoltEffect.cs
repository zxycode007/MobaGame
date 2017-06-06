using UnityEngine;
using System.Collections;

namespace MobaGame
{
	public class FireBoltEffect: GameContext
	{
		public Actor caster;
		public Actor target;
		public float speed;
		// Use this for initialization
		public FireBolt bolt;

		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{
			if(target != null)
			{
				transform.LookAt (transform.position);
				transform.position += transform.forward * speed * Time.deltaTime;
				if(Vector3.Distance (target.transform.position, transform.position) < 1.0F)
				{
					Debug.Log ("击中" + target.creatureName);
					GameObject obj = Global.GetPrefab ("FireBoltHit");
                    //Resources.Load("FireBoltHit") as GameObject;
					if (obj != null)
					{
						 
						GameObject hitEffect = Instantiate(obj, transform.position, transform.rotation) as GameObject;

					}
					BeDamageEvtArg arg = new BeDamageEvtArg ();
					arg.srcUnitID = caster.GetInstanceID ();
					arg.descUnitID = target.GetInstanceID ();
					arg.value = caster.intelligence * 10 + 100;
					FireEvent (this, EventType.EVT_BE_DAMAGED, arg);
					 

					Destroy (gameObject);
				}
			}else
			{
				Destroy (gameObject);
			}

		}

		 
	}
}


