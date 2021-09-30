using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;
using Assets.GameLogic.Scripts.GameEntities.Models;
using Assets.GameLogic.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{
    /// <summary>
    /// Класс описывает объект Лазер
    /// </summary>
    public class Laser : MonoBehaviour
    {
        [SerializeField] private LaserSettings laserSettings;

        private ShotsBehindScreenDisposer destroyOffscreen;
        private CollisionWithAsteroid asteroidCollision;
        private CollisionWithEnemyShip enemyShipCollision;

        private Armory armory;

        private int damage;
        //private IMoveAlgorithm moveAlgorithm;

        #region Mono Methods

        void Awake()
        {
            this.destroyOffscreen = GetComponent<ShotsBehindScreenDisposer>();
            this.asteroidCollision = GetComponent<CollisionWithAsteroid>();
            this.enemyShipCollision = GetComponent<CollisionWithEnemyShip>();

            this.destroyOffscreen.DestroyShotEvent += OnEventDestroy;
            this.asteroidCollision.CollisionEvent += OnCollisionWithAsteroid;
        }

        void Update()
        { }

        #endregion        

        #region Public API

        public void InitializeShot(Armory armoryObj, int damageValue)
        {
            armory = armoryObj;
            damage = damageValue;
        }

        #endregion

        #region Private Methods
        
        private void OnCollisionWithAsteroid(Asteroid asteroid)
        {
            asteroid.HandleCollision(int.MaxValue);
            
            if (this.gameObject.tag == new ApplicationTags().ShortLaser)
            {
                OnEventDestroy();
            }
        }

        private void OnCollisionWithEnemyShip(Ship enemyShip)
        {
            if (this.gameObject.tag.ToLower() == new ApplicationTags().ShortLaser.ToLower())
            {
                OnEventDestroy();
            }
        }

        private void OnEventDestroy()
        {
            if (armory)
            {
                armory.ReleaseObject(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

    }
}
