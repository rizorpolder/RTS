using UnityEngine;

namespace MyProject
{
    public class Vision
    {
        public float ActiveDistance = 10;
        public float ActiveAngle = 35;

        public bool VisionM(Transform player, Transform target)
        {
            return Distance(player, target) && Angle(player, target) && !CheckBlocked(player, target);
        }
        /// <summary>
        /// Проверка на наличие препятствия между ботом и целью.
        /// </summary>
        /// <param name="player">Трансформ Бота</param>
        /// <param name="target">Трансформ цели(игрок)</param>
        /// <returns></returns>
        private bool CheckBlocked(Transform player, Transform target)
        {
            if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
            return hit.transform != target;
        }

        /// <summary>
        /// Проверка угла 
        /// </summary>
        /// <param name="player">Трансформ бота</param>
        /// <param name="target">Трансформ цели(игрок)</param>
        /// <returns></returns>
        private bool Angle (Transform player, Transform target)
        {
            
            var angle = Vector3.Angle(player.forward, player.position - target.position);
            return angle <= ActiveAngle;
        }
        /// <summary>
        /// Проверка дистанции
        /// </summary>
        /// <param name="player">Трансформ бота</param>
        /// <param name="target">Трансформ цели(игрока)</param>
        /// <returns></returns>
        private bool Distance (Transform player, Transform target)
        {
            var dist = Vector3.Distance(player.position, target.position);
            return dist <= ActiveDistance;
        }
    }
}
