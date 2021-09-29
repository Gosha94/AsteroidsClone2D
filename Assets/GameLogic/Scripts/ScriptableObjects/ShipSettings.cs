using UnityEngine;

namespace Assets.GameLogic.Scripts
{
    [CreateAssetMenu(menuName = "Ship/Settings", fileName = "ShipData")]
    public class ShipSettings : ScriptableObject
    {
        
        [SerializeField] private float turnSpeed = 15f;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private bool  useAi = false;

        public float TurnSpeed { get => this.turnSpeed; }
        public float MoveSpeed { get => this.moveSpeed; }
        public bool UseAi { get => this.useAi; }

    }
}
