using UnityEngine;

namespace Assets.GameLogic.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Asteroid/Settings", fileName = "AsteroidData")]
    public class AsteroidSettings : ScriptableObject
    {
        [SerializeField] private float asteroidLinearSpeed = 1f;

        public float AsteroidLinearSpeed { get => this.asteroidLinearSpeed; }

    }
}
