using System;
using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.Models;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

    /// <summary>
    /// Класс-обработчик коллизий объекта с Астероидом
    /// </summary>
    public class CollisionWithAsteroid : MonoBehaviour, ICollisionWith<Asteroid>
    {

        public event Action<Asteroid> CollisionEvent;

        public void OnTriggerEnter2D(Collider2D collider)
        {
            string tag = collider.tag.ToLower();

            if (tag == new ApplicationTags().Asteroid)
            {
                Asteroid asteroid = collider.gameObject.GetComponentInParent<Asteroid>();

                CollisionEvent?.Invoke(asteroid);
            }
        }
    }
}
