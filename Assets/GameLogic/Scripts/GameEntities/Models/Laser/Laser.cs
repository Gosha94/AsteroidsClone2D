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
        private CollisionWithAsteroid collision;        
        private Armory armory;

        private int damage;
        //private IMoveAlgorithm moveAlgorithm;

        #region Mono Methods

        void Awake()
        {
            this.destroyOffscreen = new ShotsBehindScreenDisposer();
            this.collision = new CollisionWithAsteroid();

            destroyOffscreen.DestroyShotEvent += OnEventDestroy;
            collision.CollisionEvent += OnCollisionWithAsteroid;
        }

        void Update()
        {
            
            //moveAlgorithm.MovingBasedOnAlgorithm(this.transform);
        }

        #endregion        

        #region Public API

        public void InitializeShot(Armory armoryObj, int damageValue)
        {
            armory = armoryObj;
            damage = damageValue;
        }

        #endregion

        #region Private Methods

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
        
        private void OnCollisionWithAsteroid(Asteroid asteroid)
        {
            asteroid.GetCollision(damage);
            OnEventDestroy();
        }

        #endregion

    }
}
