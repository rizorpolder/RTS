using MyProject.Interface;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace MyProject.Moving
{
    class UnitMoving : MonoBehaviour,IMove
    {

        private Transform _transform; // трансформ юнита
        private Transform _point;
        private Ray _ray;
        private RaycastHit _hit;
        private bool IsMoving = false;
        private Queue<Vector3> _points = new Queue<Vector3>();
        private LineRenderer _lineRenderer;
        public Vector3 offset = new Vector3(0, 1.5f, 0); // оффсет относительно смещения пивода юнита
        private NavMeshPath _path;
        public float speed = 0.1f; // скорость движения
        public float radius = 0.2f;// радиус остановки от точки
        private Vector3 _startPoint;

        public UnitMoving(Transform transform)
        {
            _transform = transform;
            
            _startPoint = transform.position;
            _path = new NavMeshPath();


        }
        public void Move()
        {
            GetPoint();
        }
        public void GetPoint()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                //if (Input.GetMouseButtonDown(0))
                
                    DrawPoint(hit.point);
                
                if (Time.frameCount % 2 == 0)
                {
                    NavMesh.CalculatePath(_startPoint, hit.point, NavMesh.AllAreas, _path);
                  

                }
            }
        }
        private void DrawPoint(Vector3 position)
        {
            var point = Instantiate(_point, position, Quaternion.identity);
            _points.Enqueue(point.position);
        }
    }
}
#region OldCode
//        private void MouseClick() // вынести в InputController
//        {
//            _ray = Camera.main.ScreenPointToRay(Input.mousePosition); //проблема null exc

//            //нужно как то получить из inputController луч. и передать сюда... тогда интерфейс отваливается.
//            //нужно подумать

//            if (Physics.Raycast(_ray, out _hit))
//            {

//                if (_hit.transform.tag == "Ground")
//                {
//                    queue.Enqueue(_hit.point);
//                    MoveProc(queue.Peek());
//                    //MoveProc(_hit.point);////внимание!!!!
//                }
//            }

//        }

//        //private void CharacterMove(Vector3 point) // это и есть move
//        //{
//        //    if (IsMoving)
//        //    {
//        //        StopCoroutine("MoveProc"); // monoBehaviour
//        //    }
//        //    StartCoroutine("MoveProc", point);
//        //}

//        private void  MoveProc(Vector3 point)
//        {
//            IsMoving = true;

//            _transform.LookAt(point + offset);

//            while (IsMoving)
//            {
//                _transform.position = _transform.position + _transform.forward * speed * Time.deltaTime;

//                if (Vector3.Distance(_transform.position, point + offset) < radius)
//                {
//                    queue.Dequeue();
//                    IsMoving = false;
//                }
//               // yield return null;
//            }
//            //yield break;
//        }


//    }
//}
#endregion