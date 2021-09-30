using System;
using UnityEngine;
using Assets.GameLogic.Scripts;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.Models;
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
    private GameObject playerShipForFollow;

    private Health shipHealth;
    private ShipDied shipDied;

    private CollisionWithAsteroid withAsteroidCollision;
    private CollisionWithEnemyShip withEnemyShipCollision;

    #endregion

    #region Public Properties

    public event Action<Ship, int, Vector3> ShipDiedEvent;
    public float ShipSpeed { get => shipInput.Thrust; }
    public float ShipAngle { get => this.gameObject.transform.rotation.z; }

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

        if (gameObject.tag == new ApplicationTags().Player)
        {
            this.withAsteroidCollision.CollisionEvent += OnCollisionWithAsteroid;
        }

        this.withEnemyShipCollision = GetComponent<CollisionWithEnemyShip>();
        this.withEnemyShipCollision.CollisionEvent += OnCollisionWithEnemyShip;

        this.shipDied = GetComponent<ShipDied>();
        this.shipDied.ShipDieCompleteEvent += OnShipDie;

        this.shipHealth = GetComponent<Health>();

        if (shipSettings.UseAi)
        {
            this.playerShipForFollow = GameObject.FindGameObjectWithTag(new ApplicationTags().Player);
            this.shipInput = new AiAutomaticInput(this, this.playerShipForFollow, shipSettings.MoveSpeed);
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

        DeactivateShipObject();

        ApplicationLoggerService.LogCollision(this.gameObject.tag, asteroid.tag);
    }

    private void OnCollisionWithEnemyShip(Ship enemyShip)
    {
        shipDied.Die();

        DeactivateShipObject();

        ApplicationLoggerService.LogCollision(this.gameObject.tag, gameObject.tag);
    }

    /// <summary>
    /// Метод отключает объект Корабль
    /// </summary>
    private void DeactivateShipObject()
    {        
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Метод пробуждающий событие при уничтожении игрока
    /// </summary>
    private void OnShipDie()
    {
        ShipDiedEvent?.Invoke(this, this.shipSettings.PointsPerDestroying, this.gameObject.transform.position);
    }

    #endregion


}