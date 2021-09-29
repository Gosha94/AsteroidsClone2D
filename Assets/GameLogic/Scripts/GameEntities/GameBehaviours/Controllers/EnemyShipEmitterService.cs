using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.ScriptableObjects;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    public class EnemyShipEmitterService : MonoBehaviour, IEmitterService
    {

        #region Private Fields

        [SerializeField] private GameObject enemyShipPrefab;
        [SerializeField] private GameEntitesEmitterSettings emitterSettings;

        private List<Ship> shipsList;

        #endregion

        #region Public Properties

        public int GameEntitiesLeft { get => this.shipsList.Count; }

        public event Action<int> EntityDestroyedEvent;

        #endregion

        #region Mono Methods

        private void Awake()
        {
            ResetEmitter();
        }

        #endregion

        #region Public API

        public void ResetEmitter()
        {

        }

        public void SpawnGameEntity()
        {

        }

        #endregion

    }
}
