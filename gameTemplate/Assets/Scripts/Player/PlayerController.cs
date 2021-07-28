using System;
using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Player
{       // делегирование и инкапсуляция
    // САМЫЙ ВЫСШИЙ БЛОК 
    public class PlayerController : MonoBehaviour , IPlayerController
    {
        [SerializeField] private FightingSystem _fightingSystem;
        [SerializeField] private AnimationSystem animSystem;
        [SerializeField] private MovingSystem _movingSystem;
        [SerializeField] private HealthSystem _healthSystem;

        public event Action OnInitialized; // delegate
        public event Action OnDied;

        private PlayerData _playerData;
        private StateController _stateController;

        private void Start()
        {
            Init();
            
        }

        public void Init() 
        {
            // сначала проинициализировать все данные , а потом их начать передавать (null reference exc)
            _playerData = new PlayerData();
            _stateController = new StateController(this);
            animSystem.Initialize(_stateController,this);
            _movingSystem.Initialize(_stateController);
            _healthSystem.Initialize(_playerData);
            _fightingSystem.Initialize(_stateController);
        }

        public void TakeDamage(float damage)
        {
            _healthSystem.Hit(damage);
            if (_playerData.Health <= 0)
            {
                OnDied?.Invoke();
            }
            else
                animSystem.RecieveDamage();
            // anim systen take hit
        }

        public bool isDied()
        {
            return _stateController.Died;
        }
        
    }
}
