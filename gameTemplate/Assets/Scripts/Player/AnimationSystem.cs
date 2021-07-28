using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Player
{
    public class AnimationSystem : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private StateController _stateController;
        private PlayerController _playerСontroller;
        
        public void Initialize(StateController stateController,PlayerController playerСontroller)
        {
            _stateController = stateController;
            _playerСontroller = playerСontroller;
            
            _playerСontroller.OnDied += Die;
        }

        public void AnimateMove(float direction, float speed)
        {
            animator.SetFloat("DirectionX", direction);
            animator.SetFloat("DirectionZ", speed);
        }

        public void StartAttack(string attackTriggerVariation)
        {
            animator.SetTrigger(attackTriggerVariation);
            animator.SetBool("Attacking", true);
            _stateController.Attacking = true;
        }

        public void EndAttack()
        {
            animator.SetBool("Attacking", false);
            _stateController.Attacking = false;
        }
        
        public void RecieveDamage()
        {
            animator.SetBool("RecieveDmg",true);
            _stateController.RecievingDamage = true;
        }

        public void EndRecievingDamage()
        {
            animator.SetBool("RecieveDmg",false);
            _stateController.RecievingDamage = false;
        }

        private void Die()
        {
            animator.SetBool("HitPointsEmpty",true);
            _playerСontroller.OnDied -= Die;
        }
        
    }
}