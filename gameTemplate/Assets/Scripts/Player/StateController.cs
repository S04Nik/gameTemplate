
namespace Stepan.Fight3D.GameScripts.Player
{
    // УБРАТЬ !!!!! ВІНЕСТИ В ОТДЕЛЬНІЕ КЛАССІ 
    public class StateController
    {
        public bool Attacking;
        public bool Died { get; private set; }
        public bool AttackFinished = false;
        public bool RecievingDamage = false;
        public StateController(PlayerController playerСontroller)
        {
            Died = false;
            Attacking = false;
            playerСontroller.OnDied+= SetDieState;
        }

        private void SetDieState()
        {
            Died = true;
        }
    }
}
