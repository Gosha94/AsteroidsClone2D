using System;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
	public class ShotsBehindScreenDisposer : BehindScreenBase
    {
        public event Action DestroyShotEvent;

		public override void Update()
		{
			base.Update();
			
			if (isOffscreen)
			{
				if (DestroyShotEvent != null)
				{
					DestroyShotEvent();
				}
				else
				{
					Destroy(this.gameObject);
				}
			}
		}

	}
}
