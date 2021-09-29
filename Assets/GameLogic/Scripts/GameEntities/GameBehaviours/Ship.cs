using UnityEngine;
using Assets.GameLogic.Scripts;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.GameEntities.Models;
using System;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours;

/// <summary>
/// ����� ���������� ��������� ������������ ������� � ����
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
    /// ����� ���������� ������ �������
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
    /// ����� ����������� ��� ������������ ������� � ������� ��������
    /// </summary>
    /// <param name="asteroid">������ ��������</param>
    private void OnCollisionWithAsteroid(Asteroid asteroid)
    {
        // ���������� ��������
        asteroid.GetCollision(int.MaxValue);

        // ��������� ������ �������
        gameObject.SetActive(false);

    }

    /// <summary>
    /// ����� ������������ ������� ��� ����������� ������
    /// </summary>
    private void OnPlayerDie()
    {
        PlayerDiedEvent?.Invoke();
    }

    #endregion


}