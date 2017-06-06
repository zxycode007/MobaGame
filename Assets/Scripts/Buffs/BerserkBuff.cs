using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class BerserkBuff : BaseBuff {

		public BerserkBuff()
		{
			
		}

		public override void Invoke ()
		{
			 
		}

		public override void OnAddBuff()
		{
			Owner.attackSpeed += Owner.defaultData.attackSpeed * 0.5F;
			Owner.speed += Owner.defaultData.speed * 0.5F;
			Owner.changeAttackSpeed (Owner.attackSpeed);
			Owner.changeSpeed (Owner.speed);

		}

		public override void OnRemoveBuff()
		{
			Owner.attackSpeed -= Owner.defaultData.attackSpeed * 0.5F;
			Owner.speed -= Owner.defaultData.speed * 0.5F;
			Owner.changeAttackSpeed (Owner.attackSpeed);
			Owner.changeSpeed (Owner.speed);
		}

	}
}

