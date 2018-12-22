using UnityEngine;


/// <summary>
/// Переписать управление под точки, сделать 2 префаба (герой, враг), сделать аптечки и аналог ISetDamage для них
/// </summary>
namespace MyProject
{
    class Main : MonoBehaviour
    {
       
        public InputController InputController { get; private set; }

        public PlayerController PlayerController { get; set; }
        public BotController BotController { get; private set; }
        

        public Transform Player { get; private set; }
        public Transform MainCamera { get; private set; }

        public Bot bot;
        public int CountBot;

        private BaseController[] controllers;

        public static Main Instance { get; private set; }

        public void Awake()
        {
            Instance = this;
            MainCamera = Camera.main.transform;
            
            Player = GameObject.FindGameObjectWithTag("Player").transform;
            BotController = new BotController();

            PlayerController = new PlayerController(new UnitMovingWASD(Player));
            //PlayerController = new PlayerController(new UnitMoving(Player));
            InputController = new InputController();
            InputController.On();

            BotController = new BotController { CountBot = CountBot };

            controllers = new BaseController[3]
            {
                InputController,
                PlayerController,
                BotController
            };
        }

        private void Start()
        {
            InputController.On();
            BotController.On();
            BotController.Init();
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
