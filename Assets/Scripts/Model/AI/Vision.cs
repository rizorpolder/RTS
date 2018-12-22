using UnityEngine;

namespace MyProject
{
    public class Vision
    {
        public float ActiveDistance = 10f;
        public float ActiveAngle = 35f;

        public bool VisionM(Transform player, Transform target)
        {
            return Distance(player, target) && Angle(player, target); //&& !CheckBlocked(player, target);
        }

        //private bool CheckBlocked(Transform player,Transform target)
        //{
        //    if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
        //        return hit.transform != target;
        //}
        private bool Angle (Transform player, Transform target)
        {
            
            var angle = Vector3.Angle(player.forward, player.position - target.position);
            return angle <= ActiveAngle;
        }

        private bool Distance (Transform player, Transform target)
        {
            var dist = Vector3.Distance(player.position, target.position);
            return dist <= ActiveDistance;
        }
    }
}
