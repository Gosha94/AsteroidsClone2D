using UnityEngine;
using Assets.GameLogic.Scripts;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.Models;
using System;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours;

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
        this.shipHealth = new Health();
        this.shipHealth.HealthIsEmptyEvent += OnPlayerDie;

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
        asteroid.GetCollision(int.MaxValue);

        // Отключаем объект Корабля
        gameObject.SetActive(false);

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