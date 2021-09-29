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
        [SerializeField] private int numOfObjects = 5;

        private List<GameObject> pool;
        private bool hasInitialised;

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

        //public void Init()
        //{
        //    pool = new List<GameObject>(numOfObjects);
        //    for (int i = 0; i < numOfObjects; i++)
        //    {
        //        AddShotToObjectPool();
        //    }
        //    hasInitialised = true;
        //}

        //public GameObject GetGameObject()
        //{
        //    if (!hasInitialised)
        //    {
        //        return null;
        //    }

        //    for (int i = 0; i < pool.Count; i++)
        //    {
        //        GameObject ob = pool[i];
        //        if (!ob.activeSelf)
        //        {
        //            ob.transform.Translate(Vector3.zero);
        //            ob.transform.rotation = Quaternion.identity;
        //            ob.SetActive(true);
        //            return ob;
        //        }
        //    }

        //    GameObject additionalObj = AddShotToObjectPool();
        //    additionalObj.SetActive(true);
        //    return additionalObj;
        //}

        public void ReleaseObject(GameObject go)
            => go.SetActive(false);

        public void ReleaseAll()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                GameObject ob = pool[i];
                ob.SetActive(false);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод добавляет объект выстрела в список для контроля выпущенных снарядов
        /// </summary>
        /// <returns></returns>
        //private GameObject AddShotToObjectPool()
        //{
        //    var gameObj = Instantiate(spawnPrefab, Vector3.zero, Quaternion.identity);
        //    if (optionalParent == null)
        //    {
        //        gameObj.transform.SetParent(this.transform);
        //    }
        //    else
        //    {
        //        gameObj.transform.SetParent(optionalParent.transform, true);
        //    }
        //    gameObj.SetActive(false);
        //    pool.Add(gameObj);
        //    return gameObj;
        //}

        #endregion

    }
}
