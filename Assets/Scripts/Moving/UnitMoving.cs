using MyProject.Controllers;
using MyProject.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject.Moving
{
    class UnitMoving:IMove
    {
        
        private Transform _transform; // трансформ юнита
        private Ray _ray;
        private RaycastHit _hit;
        private bool IsMoving = false;
        private Queue<Vector3> queue = new Queue<Vector3>();

        public Vector3 offset = new Vector3(0, 1.5f, 0); // оффсет относительно смещения пивода юнита

        public float speed = 0.1f; // скорость движения
        public float radiud = 0.2f;// радиус остановки от точки

        
        public UnitMoving(Transform transform)
        {
            _transform = transform;
        }
        public void Move()
        {
            
            MouseClick();
            if (queue.Count < 1) return;
            // MoveProc(queue.Peek());
        }

        private void MouseClick() // вынести в InputController
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition); //проблема null exc

            //нужно как то получить из inputController луч. и передать сюда... тогда интерфейс отваливается.
            //нужно подумать

            if (Physics.Raycast(_ray, out _hit))
            {

                if (_hit.transform.tag == "Ground")
                {
                    queue.Enqueue(_hit.point);
                    MoveProc(queue.Peek());
                    //MoveProc(_hit.point);////внимание!!!!
                }
            }

        }

        //private void CharacterMove(Vector3 point) // это и есть move
        //{
        //    if (IsMoving)
        //    {
        //        StopCoroutine("MoveProc"); // monoBehaviour
        //    }
        //    StartCoroutine("MoveProc", point);
        //}

        private void  MoveProc(Vector3 point)
        {
            IsMoving = true;

            _transform.LookAt(point + offset);

            while (IsMoving)
            {
                _transform.position = _transform.position + _transform.forward * speed * Time.deltaTime;

                if (Vector3.Distance(_transform.position, point + offset) < radiud)
                {
                    queue.Dequeue();
                    IsMoving = false;
                }
               // yield return null;
            }
            //yield break;
        }
       

    }
}
