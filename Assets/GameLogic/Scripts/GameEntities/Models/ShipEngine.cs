using Assets.GameLogic.Scripts.Contracts;
using UnityEngine;

namespace Assets.GameLogic.Scripts
{
    /// <summary>
    /// Класс оперделяет модель движения космического корабля
    /// </summary>
    public class ShipEngine : IEngine
    {
        private readonly IShipInput shipInput;
        private readonly Transform transformToMove;
        private readonly ShipSettings shipSettings;

        public ShipEngine(IShipInput input, Transform transform, ShipSettings settings)
        {
            this.shipInput = input;
            this.transformToMove = transform;
            this.shipSettings = settings;
        }

        public void Tick()
        {
            this.transformToMove.Rotate(new Vector3(0, 0, -this.shipInput.Rotation), this.shipSettings.TurnSpeed * Time.deltaTime);
            this.transformToMove.position += ( this.shipInput.Thrust * (this.transformToMove.up * this.shipSettings.MoveSpeed) * Time.deltaTime );
        }

    }
}
