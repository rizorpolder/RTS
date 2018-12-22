using UnityEngine;

namespace MyProject
{
    public struct MyCollision
    {
        private readonly Vector3 _dir;
        private readonly float _damage;
        private readonly ContactPoint _contact;
        private readonly Transform _objCollision;
        public MyCollision(float damage, ContactPoint contact, Transform objCollision,Vector3 dir = default(Vector3))
        {
            _damage = damage;
            _dir = dir;
            _contact = contact;
            _objCollision = objCollision;
        }

        public Vector3 Dir
        {
            get { return _dir; }
        }

        public float Damage
        {
            get
            {
                return _damage;
            }

        }
        public ContactPoint Contact
        {
            get { return _contact; }
        }
        public Transform ObjCollision
        {
            get { return _objCollision; }
        }
    }
}
