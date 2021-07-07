using Tools;
using UnityEngine;

namespace Game.Background
{
    internal sealed class BackgroundController : BaseController
    {   
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Background" };
        private readonly BackgroundView _view;
        private readonly SubscriptionProperty<float> _diff;
        private readonly ISubscriptionProperty<float> _leftMove;
        private readonly ISubscriptionProperty<float> _rightMove;

        public BackgroundController(ISubscriptionProperty<float> leftMove,
            ISubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            _diff = new SubscriptionProperty<float>();
            _leftMove = leftMove;
            _rightMove = rightMove;
            _view.Init(_diff);
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(Move);
            _rightMove.UnSubscriptionOnChange(Move);
            base.OnDispose();
        }

        private BackgroundView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<BackgroundView>();
        }

        private void Move(float value)
        {
            _diff.Value = value;
        }
    }
}
