using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;

namespace Assets.GameLogic.Scripts
{
    public class PlayerControllerInput : IShipInput
    {

        public float Rotation { get; private set; }
        public float Thrust { get; private set; }

        public bool PrimaryWeaponFire { get; private set; }

        public bool SeconaryWeaponFire { get; private set; }

        public void ReadInput()
        {
            this.Rotation = Input.GetAxis("Horizontal");
            this.Thrust = Input.GetAxis("Vertical");

            this.PrimaryWeaponFire = Input.GetMouseButtonDown(0);
            this.SeconaryWeaponFire = Input.GetMouseButtonDown(1);
        }

    }
}
