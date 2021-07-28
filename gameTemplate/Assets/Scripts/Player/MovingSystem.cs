using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Player
{
    public class MovingSystem : MonoBehaviour
    {
        [SerializeField] private CharacterController chController;
        [SerializeField] private  AnimationSystem animationSystem;
        
        public float speed;
        public float walkSpeed=5f;
        public float runSpeed=10f;
        
        private float _gravity = -10f;
        private float _deltaX;
        private float _deltaZ;
        private StateController _stateController;
       
        public void Initialize(StateController stateController)
        {
            _stateController = stateController;
        }
        void Update()
        {
            if (_stateController.Attacking == false && _stateController.Died==false && _stateController.RecievingDamage==false)
            {
                _deltaX = Input.GetAxis("Horizontal");
                _deltaZ = Input.GetAxis("Vertical");

                if (!Input.GetButton("SpeedUp"))
                {
                    _deltaX /= 2;
                    _deltaZ /= 2;
                    speed = walkSpeed;
                }
                else
                {
                    speed = runSpeed;
                }

                animationSystem.AnimateMove(_deltaX, _deltaZ);

                Vector3 movementV = new Vector3(_deltaX * speed, 0, _deltaZ * speed) * speed;
                movementV = Vector3.ClampMagnitude(movementV, speed) * Time.deltaTime; // ограничение движения по диагонали 
                //движение по диагонали происходило бы быстрее движения вдоль координатных осей

                movementV.y = _gravity;
                movementV = transform.TransformDirection(movementV); // from local space to world space.

                chController.Move(movementV); //методу Move() следует передавать вектор движения, определенный в глобальном пространстве


                _deltaX = 0;
                _deltaZ = 0;
            }

        }


    }
}