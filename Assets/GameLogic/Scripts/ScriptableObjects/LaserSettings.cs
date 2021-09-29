using UnityEngine;

namespace Assets.GameLogic.Scripts.ScriptableObjects
{

    /// <summary>
    /// Класс настроек для объекта Лазер
    /// </summary>
    [CreateAssetMenu(menuName = "Laser/Settings", fileName = "LaserData")]
    public class LaserSettings : ScriptableObject
    {
        [SerializeField] private float laserSpeed = 1.0f;

        public float LaserSpeed { get => this.laserSpeed; }

    }

}
