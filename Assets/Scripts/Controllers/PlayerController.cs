using MyProject.Interface;

namespace MyProject.Controllers
{
    public class PlayerController : BaseController
    {
        private IMove _unit;

        public PlayerController(IMove move)
        {
            _unit = move;
        }
        public override void MyUpdate()
        {
            _unit.Move();
        }
    }
}