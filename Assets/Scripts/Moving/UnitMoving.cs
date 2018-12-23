//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;
//namespace MyProject
//{
//    class UnitMoving : IRTSMove
//    {

//        private Transform _transform; // трансформ юнита
//        private Transform _point;
//        private Ray _ray;
//        private RaycastHit _hit;
//        private bool IsMoving = false;
//        private Queue<Vector3> _points = new Queue<Vector3>();
//        private LineRenderer _lineRenderer;
//        public Vector3 offset = new Vector3(0, 1.5f, 0); // оффсет относительно смещения пивода юнита
//        private NavMeshPath _path;
//        public float speed = 0.1f; // скорость движения
//        public float radius = 0.2f;// радиус остановки от точки
//        private Vector3 _startPoint;

//        public UnitMoving(Transform transform)
//        {
//            _transform = transform;

//            _startPoint = transform.position;
//            _path = new NavMeshPath();


//        }
//        public void Move(Vector3 temp)
//        {
//            MouseClick(temp);
//        }
//        public void MouseClick(Vector3 temp)
//        {
//            _ray = Camera.main.ScreenPointToRay(temp);
//            if(Physics.Raycast(_ray, out _hit))
//            {
//                    if(_hit.transform.tag== "ground") // заменить на navMesh
//                {
//                    MoveChar(_hit.point);
//                }
                        
//            }
//        }

//        private void MoveChar(Vector3 point)
//        {
//            IsMoving = true;
//            _transform.LookAt(point + offset);
//            while (IsMoving)
//            {
//                _transform.position = _transform.position + _transform.forward * speed * Time.deltaTime;
//                if(Vector3.Distance(_transform.position,point+offset)<radius)
//                {
//                    IsMoving = false;
//                }
//            }
//        }
//    }
//}