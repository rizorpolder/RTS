using UnityEngine;

namespace MyProject.Model
{
    public class BaseObject : MonoBehaviour
    {

        public Rigidbody Rigidbody { get; set; } // инкапсулированный Rigidbody



        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>(); //получить Rigidbody при запуске приложения
        }
    }
}