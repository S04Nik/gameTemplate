using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyConfigurator:MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyController;
        [SerializeField] private EnemyConfig _enemyConfig;
        private void Start()
        {
            _enemyController.Init(_enemyConfig);
        }
    }
}