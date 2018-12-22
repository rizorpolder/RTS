using UnityEngine;
using UnityEngine.AI;
namespace MyProject
{
    public static class Move

    {

        public static Vector3 GetPoint(Transform agent)
        {
            Vector3 result;
            var dist = Random.Range(10, 20);
            var randomPoint = Random.insideUnitSphere * dist;

            NavMesh.SamplePosition(agent.position + randomPoint,
                                    out var hit,
                                    dist,
                                    NavMesh.AllAreas);
            result = hit.position;
            return result;
        }
    }
}
