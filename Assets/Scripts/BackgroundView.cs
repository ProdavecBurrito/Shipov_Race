using Tools;
using UnityEngine;

namespace Game.Background
{
    internal sealed class BackgroundView : MonoBehaviour
    {
        [SerializeField] private Background[] _backgrounds;

        private ISubscriptionProperty<float> _diff;

        public void Init(ISubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }

        private void OnDestroy()
        {
            _diff?.SubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (Background background in _backgrounds)
            {
                background.Move(value);
            }
        }
    }
}
