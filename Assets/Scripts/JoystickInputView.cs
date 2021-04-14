using JoostenProductions;
using Tools;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.InputLogic
{
    internal class InputJoystickView : BaseInputView
    {
        private const int SPEED_ALIGNMENT = 10;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void Move()
        {
            float moveStep = SPEED_ALIGNMENT * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
            if (moveStep > 0)
            {
                OnRightMove(moveStep);
            }
            else if (moveStep < 0)
            {
                OnLeftMove(moveStep);
            }
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }
    }
}
