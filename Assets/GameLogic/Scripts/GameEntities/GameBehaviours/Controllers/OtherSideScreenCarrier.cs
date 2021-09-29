using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{

    /// <summary>
    /// Класс занимается переносом объектов на противоположную сторону экрана
    /// </summary>
    public class OtherSideScreenCarrier : BehindScreenBase
    {

        public override void Update()
        {
            base.Update();
            
            if (isOffscreen)
            {
                this.transform.position = Camera.main.ViewportToWorldPoint(viewportPos);
            }
        }

    }
}
