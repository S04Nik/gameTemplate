using System;

namespace Stepan.Fight3D.GameScripts.Player
{
    public interface IPlayerController
    {
        // высший уровень
        // общение с другими блоками 
        event Action OnInitialized;
        event Action OnDied; // делегаты 
        void Init(); // ссылки на компоненты
        // принцип солид - инверсия зависимости 
        void TakeDamage(float damage);
    }
}