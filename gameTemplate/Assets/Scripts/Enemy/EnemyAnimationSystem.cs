using System;
using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyAnimationSystem : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private EnemyStateController _stateController;
        private string _attack = "Attack";
        private string _die = "Die";

        public void Initialize(EnemyStateController stateController,EnemyController enemyController)
        {
            _stateController = stateController;
            enemyController.OnDied += Die;
        }

        public void AttackStart()
        {
            if (_stateController.Died == false)
            {
                animator.SetBool(_attack, true);
                _stateController.CanMakeHit = true;
            }
        }

        public void AttackFinish()
        {
            animator.SetBool(_attack, false);
        }
        public bool AttackBool()
        {
            return animator.GetBool(_attack);
        }
        private void Die()
        {
          animator.SetBool(_die,true);
        }

        public void WallkStart()
        {
            animator.SetBool("Wallk",true);
        }
        public void WallkFinish()
        {
            animator.SetBool("Wallk",false);
        }
        public void IdleWait()
        {
            animator.SetBool("IdleWait",true);
        }

        public void IdleWaitFinish()
        {
            animator.SetBool("IdleWait",false);
        }

        public void StartReceivingHit()
        {
            animator.SetBool("ReceiveHit",true);
        }

        public void FinishReceivingHit()
        {
            animator.SetBool("ReceiveHit",false);
        }
    }
}