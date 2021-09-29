using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;

namespace Assets.GameLogic.Scripts
{
    public class AiAutomaticInput : IShipInput
    {

        private readonly Ship aiShipObject;
        private readonly GameObject playerShip;

        public AiAutomaticInput(Ship enemyShip, GameObject playerShip)
        {
            this.aiShipObject = enemyShip;
            this.playerShip = playerShip;
        }

        public float Rotation { get; private set; }
        public float Thrust { get; private set; }

        public void ReadInput()
        {
            FollowPlayerShip();
        }

        /// <summary>
        /// Метод следования за игроком
        /// </summary>
        private void FollowPlayerShip()
        {
            Vector3 moveDir = 
                this.playerShip.transform.position - 
                this.aiShipObject.transform.position - 
                new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            this.aiShipObject.transform.position += moveDir.normalized * 0.2f * Time.deltaTime;
        }

        #region Not Implemented Elements

        public bool PrimaryWeaponFire =>
            throw new System.NotImplementedException();

        public bool SeconaryWeaponFire =>
            throw new System.NotImplementedException();

        #endregion

    }
}
