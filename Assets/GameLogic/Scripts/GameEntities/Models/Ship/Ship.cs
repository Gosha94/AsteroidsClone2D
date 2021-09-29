using UnityEngine;
using Assets.GameLogic.Scripts;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.Models;
using System;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;

/// <summary>
/// Класс определяет поведение Космического корабля в игре
/// </summary>
public class Ship : MonoBehaviour
{

    #region Private Fields

    [SerializeField] private ShipSettings shipSettings;

    private IShipInput shipInput;
    private ShipEngine shipMotor;
    private GameObject playerShip;

    private Health shipHealth;
    private ShipDied shipDied;

    private CollisionWithAsteroid withAsteroidCollision;
    private CollisionWithEnemyShip withEnemyShipCollision;

    #endregion

    #region Public Properties

    public event Action PlayerDiedEvent;

    public int ShipHealth { get => shipHealth.HealthValue; }

    #endregion

    #region Constructor

    #endregion

    #region Public API

    /// <summary>
    /// Метод отображает объект корабля
    /// </summary>
    public void ShipSpawn()
    {
        this.gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(true);
    }

    #endregion
    
    #region Mono Methods

    private void Awake()
    {
        this.withAsteroidCollision = GetComponent<CollisionWithAsteroid>();
        this.withAsteroidCollision.CollisionEvent += OnCollisionWithAsteroid;

        this.withEnemyShipCollision = GetComponent<CollisionWithEnemyShip>();
        this.withEnemyShipCollision.CollisionEvent += OnCollisionWithEnemyShip;

        this.shipDied = GetComponent<ShipDied>();
        this.shipDied.ShipDieCompleteEvent += OnPlayerDie;

        this.shipHealth = GetComponent<Health>();
        //this.shipHealth.HealthIsEmptyEvent += OnPlayerDie;

        if (shipSettings.UseAi)
        {
            this.playerShip = GameObject.FindGameObjectWithTag("player");
            this.shipInput = new AiAutomaticInput(this, this.playerShip);
        }
        else
        {
            this.shipInput = new PlayerControllerInput();
        }
        
        this.shipMotor =
            new ShipEngine(this.shipInput, this.transform, this.shipSettings);
    }

    private void Update()
    {
        shipInput.ReadInput();
        shipMotor.Tick();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Метод запускаемый при столкновении корабля с игровым объектом
    /// </summary>
    /// <param name="asteroid">Объект Астероид</param>
    private void OnCollisionWithAsteroid(Asteroid asteroid)
    {
        // Уничтожаем Астероид
        asteroid.HandleCollision(int.MaxValue);
        this.shipHealth.ReduceHealth(int.MaxValue);

        shipDied.Die();

        // Отключаем объект Корабля
        gameObject.SetActive(false);

        ApplicationLoggerService.LogCollision(this.gameObject.tag, asteroid.tag);
    }

    private void OnCollisionWithEnemyShip(Ship enemyShip)
    {
        ApplicationLoggerService.LogCollision(this.gameObject.tag, enemyShip.tag);
    }

    /// <summary>
    /// Метод пробуждающий событие при уничтожении игрока
    /// </summary>
    private void OnPlayerDie()
    {
        PlayerDiedEvent?.Invoke();
    }

    #endregion


}