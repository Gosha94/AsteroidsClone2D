using UnityEngine;
using System.Collections.Generic;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

    /// <summary>
    /// Класс описывает Арсенал оружия игры
    /// </summary>
    public class Armory : MonoBehaviour
    {

        #region Private Fields

        [SerializeField] private GameObject[] ammunitionBoxArr;
        [SerializeField] private GameObject optionalParent;

        #endregion

        #region Constructor

        #endregion

        #region Public API

        /// <summary>
        /// Метод получения объекта мини снаряда для выстрела
        /// </summary>
        /// <returns></returns>
        public GameObject GetMiniLaserForShot()
            => ammunitionBoxArr[0];

        /// <summary>
        /// Метод получения объекта мега снаряда для выстрела
        /// </summary>
        /// <returns></returns>
        public GameObject GetMegaLaserForShot()
            => ammunitionBoxArr[1];

        public void ReleaseObject(GameObject go)
            => go.SetActive(false);

        #endregion

        #region Private Methods

        #endregion

    }
}
