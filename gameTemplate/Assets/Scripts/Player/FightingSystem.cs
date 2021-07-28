using System;
using Stepan.Fight3D.GameScripts.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Stepan.Fight3D.GameScripts.Player
{

    public class FightingSystem : MonoBehaviour
    {
        [SerializeField] private AnimationSystem animSys;
        private readonly string AttackId0 = "Attack0";
        private readonly string AttackId1 = "Attack1";
        private StateController _stateController;
        private EnemyController _enemyController;
        private float damage = 20;
        
        public void Initialize(StateController stateController)
        {
            _stateController = stateController;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)&&_stateController.Died!=true&&_stateController.Attacking!=true)
            {
                // может  вызваться несколько раз (поле delay (timedeltatime - delay))
                // сделать небольшая задержку 
                _stateController.AttackFinished = false; // preparing state for new Attack
                var changedAttackAnimation = Random.Range(20,80);
                animSys.StartAttack(changedAttackAnimation > 50 ? AttackId0 : AttackId1);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_stateController.Died == false && _stateController.Attacking&&_stateController.AttackFinished==false)
            {
                if (other.name == "Enemy") // проблемка когда попадается колайдер руки !!!! не могу взять из него контроллер
                // НЕ ПРИВЯЗЫВАТЬСЯ К ИМЕНАМ ЛУЧШЕ ВЗЯТЬ ПРИВЯЗКУ к ТЕГАМ
                {
                    if (_enemyController == null)
                    {
                        _enemyController = other.gameObject.GetComponent<EnemyController>();
                        _enemyController.TakeDamage(damage);
                    }else
                        _enemyController.TakeDamage(damage);

                    _stateController.AttackFinished = true;
                }else if (other.name == "RightForeArm")
                {
                    if (_enemyController == null)
                    {
                        _enemyController = other.GetComponentInParent<EnemyController>();
                        _enemyController.TakeDamage(damage);
                    }else 
                        _enemyController.TakeDamage(damage);

                    _stateController.AttackFinished = true;
                }
            
            }
          
        }
    }
    
}
