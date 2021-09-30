using System;
using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.Models;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

    /// <summary>
    /// Класс-обработчик коллизий объекта с Вражеской Тарелкой
    /// </summary>
    public class CollisionWithEnemyShip : MonoBehaviour, ICollisionWith<Ship>
    {
        public event Action<Ship> CollisionEvent;

        public void OnTriggerEnter2D(Collider2D collider)
        {
            string tag = collider.tag.ToLower();

            if (tag != new ApplicationTags().Asteroid.ToLower())
            {
                Ship enemyShip = collider.gameObject.GetComponentInParent<Ship>();

                CollisionEvent?.Invoke(enemyShip);
            }
        }
    }
}