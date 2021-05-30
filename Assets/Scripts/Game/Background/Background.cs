using UnityEngine;

namespace Game.Background
{
    internal class Background : MonoBehaviour
    {
        [SerializeField]private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeedRate;

        public void Move(float speedValue)
        {
            transform.position += Vector3.right * speedValue * _relativeSpeedRate;
            Vector3 position = transform.position;
            if (position.x <= _leftBorder)
            {
                transform.position = new Vector3(_rightBorder - (_leftBorder - position.x), position.y, position.z);
            }
            else if (transform.position.x >= _rightBorder)
            {
                transform.position = new Vector3(_leftBorder + (_rightBorder - position.x), position.y, position.z);
            }
        }
    }
}
