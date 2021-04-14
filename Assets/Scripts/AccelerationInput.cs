using JoostenProductions;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal class AccelerationInput : BaseInputView
    {
        private const int SPEED_ALIGNMENT = 20;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            Vector3 direction = Vector3.zero;
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;

            if (direction.sqrMagnitude > 1)
            {
                direction.Normalize();
            }

            OnRightMove(direction.sqrMagnitude / SPEED_ALIGNMENT * _speed);
        }
    }
}
