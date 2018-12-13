using MyProject.Controllers;
using MyProject.Moving;
using UnityEngine;

namespace MyProject
{
    class Main : MonoBehaviour
    {
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; set; }
        public static Main Instance { get; private set; }
        public Transform Player { get; private set; }
        private BaseController[] controllers;

        public void Awake()
        {
            Instance = this;
            Player = GameObject.FindGameObjectWithTag("Player").transform;
            PlayerController = new PlayerController(new UnitMoving(Player));
            
            InputController = new InputController();
            InputController.On();

            controllers = new BaseController[2]
            {   
                InputController,
                PlayerController
            };
        }
        private void Update()
        {
            
            foreach (var controller in controllers)
            {
                controller.MyUpdate();
            }
        }

    }

}
