using UnityEngine;
namespace MyProject.Controllers
{
    public class InputController : BaseController
    {
        public override void MyUpdate()
        {
            if (!IsActive) return;
            if(Input.GetKeyDown("Fire1"))
            {
                Main.Instance.PlayerController.MyUpdate();
            }


        }




    }
}
