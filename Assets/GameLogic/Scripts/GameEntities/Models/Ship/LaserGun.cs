using Assets.GameLogic.Scripts.Enums;
using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

	/// <summary>
	/// Класс описывает объект Лазерная пушка
	/// </summary>
	public class LaserGun : MonoBehaviour
	{

		#region Private Fields

		[SerializeField] private float miniLaserShotFireRate = 3.0f;
		[SerializeField] private float megaLaserShotFireRate = 6.0f;
		[SerializeField] private float gunFireRate = 2.0f;
		[SerializeField] private float shotForce = 5.0f;
		[SerializeField] private Transform emitterTransform;

		private Armory armorBox;

		#endregion

		void Awake()
		{
			this.armorBox = FindObjectOfType<Armory>();
			//this.armorBox.Init();
		}

		void Update()
		{

			if (Input.GetButton("Fire1"))
			{
				ShotFromGun(ShotType.MiniLaserShot, miniLaserShotFireRate);
			}
            else if (Input.GetButton("Fire3"))
            {
				ShotFromGun(ShotType.MegaLaserShot, megaLaserShotFireRate);
			}

		}

		/// <summary>
		/// Метод выстрела из пушки корабля
		/// </summary>
		private void ShotFromGun(ShotType shotType, float fireRate)
        {
			if (Time.time > gunFireRate)
			{
				gunFireRate = Time.time + fireRate;
				
				GameObject shotPrefab;

				switch (shotType)
				{
					case ShotType.MiniLaserShot:
						shotPrefab = this.armorBox.GetMiniLaserForShot();
						break;
					case ShotType.MegaLaserShot:
						shotPrefab = this.armorBox.GetMegaLaserForShot();
						break;
					default:
						shotPrefab = new GameObject();
						break;
				}

				var instantiatedLaser = Instantiate(shotPrefab, transform.position, transform.rotation);
				var laserShotRigidBody = instantiatedLaser.GetComponent<Rigidbody2D>();
				laserShotRigidBody.AddForce(Vector3.up * shotForce);

			}
		}

	}
}