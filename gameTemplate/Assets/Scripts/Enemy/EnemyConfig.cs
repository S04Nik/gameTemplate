using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private Transform _target;
        [SerializeField] private List<Transform> _patrolPoints;
        
        public Transform Target
        {
            get => _target;
            set => _target = value;
        }
        public List<Transform> PatrolPoints             // динамически изменяемый массив
        { 
            get => _patrolPoints;
            set => _patrolPoints = value;
        }
    }
}