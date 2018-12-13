using UnityEngine;
namespace MyProject.Controllers
{
    public class InputController : BaseController
    {
        
        public override void MyUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(KeyCode.Mouse0))    
            {
                Main.Instance.PlayerController.MyUpdate();
            }


        }




    }
}
