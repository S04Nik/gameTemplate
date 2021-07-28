using UnityEngine;
using UnityEngine.AI;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyMovingSystem : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private EnemyFightingSystem _fightingSystem;
        [SerializeField] private EnemyAnimationSystem animSystem;
        
        private float lookRadius = 10f;
        private float turnSpeed = 1f;
        private int destPoint = 0;
        private EnemyConfig _enemyConfig;
        private EnemyHealthSystem _enemyHealthSystem;
        
        public void Initialize(EnemyHealthSystem healthSystem,EnemyConfig enemyConfig)
        {
            _enemyHealthSystem = healthSystem;
            _enemyConfig = enemyConfig;
        }

        private void Update()
        {
            if (_enemyHealthSystem.isAlive)
            {
                if (_enemyConfig.Target!=null)
                {
                    float distance = Vector3.Distance(_enemyConfig.Target.position, transform.position);
                    if (distance <= lookRadius)
                    {
                        if (distance <= agent.stoppingDistance)
                        {
                            animSystem.WallkFinish();
                            agent.enabled = false;
                            RotateToPlayer();
                            _fightingSystem.Attack();
                            agent.enabled = true;
                        }
                        else
                        {
                            animSystem.IdleWaitFinish();
                            animSystem.AttackFinish();
                            animSystem.WallkStart();
                            agent.enabled = true;
                            agent.SetDestination(_enemyConfig.Target.position);
                        }
                   
                    }else
                    {
                        Patrolling();
                    }
                }else
                {
                    Patrolling();
                    animSystem.WallkStart();
                }
                
            }
            
        }

        private void Patrolling()
        {
            agent.enabled = true;
            if (destPoint == _enemyConfig.PatrolPoints.Count - 1 && agent.remainingDistance< 2f)
            {
                destPoint = 0;
            }
            if (_enemyConfig.PatrolPoints.Count == 0)
                return;

            if (agent.remainingDistance < 2f)
            {
                destPoint += 1;
            }
            agent.destination = _enemyConfig.PatrolPoints[destPoint].position;

        }
        private void RotateToPlayer()
        {
            Vector3 direction = (_enemyConfig.Target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }
    }
}