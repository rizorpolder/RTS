using UnityEngine;
using UnityEngine.AI;

namespace MyProject
{
    public class Bot:BaseObjectScene, ISetDamage
    {
        private float _hp = 100f;
        public Transform Target { get; set; }
        public Vision Vision;


        public NavMeshAgent agent { get; private set; }

        private float _waitTime = 3f;

        private bool _isDead;
        private bool _isDetected;
        private bool _isReady = true;

        protected override void Awake()
        {
            base.Awake();
            _isDead = false;
            agent = GetComponent<NavMeshAgent>();
           

        }

        public void Tick()
        {
           
            if (_isDead) return;
            if(!_isDetected)
            {
                if(!agent.hasPath)
                {
                    if(_isReady)
                    {
                        _isReady = false;
                        agent.SetDestination(Move.GetPoint(transform));
                        agent.stoppingDistance = 0;
                        MyInvoke(ReadyPatrol, _waitTime);
                            
                    }
                }
                if(Vision.VisionM(transform, Target))
                {
                    _isDetected = true;
                    Debug.Log("isDetected!");
                }
            }
            else
            {
                agent.SetDestination(Target.position);
                agent.stoppingDistance = 2;
                if(Vision.VisionM(transform, Target))
                {
                    //Атака
                }
                else
                {
                    _isDetected = false;
                }
                //Потеря персонажа
            }
        }

        public void SetDamage(MyCollision info)
        {
            if(_hp>0)
            {
                _hp -= info.Damage;
            }
            if(_hp<=0)
            {
                
                _isDead = true;
                agent.enabled = false;

                foreach(Transform child in GetComponentInChildren<Transform>())
                {
                    child.parent = null;
                    
                    if(!child.gameObject.GetComponent<Rigidbody>())
                    {
                        child.gameObject.AddComponent<Rigidbody>();
                    }
                    Main.Instance.BotController.RemoveBotFromList(this);
                    Destroy(child.gameObject, 10);
                }
               
                        
            }
        }
        private void ReadyPatrol()
        {
            _isReady = true;
        }

        public void MovePoint(Vector3 point)
        {
            agent.SetDestination(point);
        }
    }
}
