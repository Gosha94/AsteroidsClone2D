using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

    /// <summary>
    /// Класс описывает линейное движение
    /// </summary>
    public class LinearMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;

        private void Update()
        {
            this.transform.Translate(this.transform.up * speed * Time.deltaTime, Space.World);
        }
    }
}
