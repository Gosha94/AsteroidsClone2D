using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;
using Assets.GameLogic.Scripts.GameEntities.Models;

namespace Assets.GameLogic.Scripts
{
    public class AiAutomaticInput : IShipInput
    {

        private readonly Ship aiShipObject;
        private GameObject playerShip;
        private readonly float shipMoveSpeed;

        public AiAutomaticInput(Ship enemyShip, GameObject playerShip, float shipSpeed)
        {
            this.aiShipObject = enemyShip;
            this.playerShip = playerShip;
            this.shipMoveSpeed = shipSpeed;
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
            if (this.playerShip == null)
            {
                this.playerShip = GameObject.FindGameObjectWithTag(new ApplicationTags().Player);
            }
            
            Vector3 moveDir =
                this.playerShip.transform.position -
                this.aiShipObject.transform.position -
                new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            this.aiShipObject.transform.position += moveDir.normalized * this.shipMoveSpeed * Time.deltaTime;

        }

        #region Not Implemented Elements

        public bool PrimaryWeaponFire =>
            throw new System.NotImplementedException();

        public bool SeconaryWeaponFire =>
            throw new System.NotImplementedException();

        #endregion

    }
}
