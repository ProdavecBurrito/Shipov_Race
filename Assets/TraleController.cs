using UnityEngine;

public class TraleController : MonoBehaviour
{
    private Touch _touch;
    private Vector3 _touchPosition;
    private TrailRenderer _trailRenderer;
    private Camera _mainCamera;
    private Vector3 lastToich;
    private Vector3 currentTouch;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.touches[0];
            if (_touch.phase == TouchPhase.Moved)
            {
                DrawTrale();
            }
            else
            {
                _trailRenderer.enabled = false;
            }
        }
    }

    private void DrawTrale()
    {
        _trailRenderer.enabled = true;
        _touchPosition = _mainCamera.ScreenToWorldPoint(_touch.position);
        _touchPosition.z = transform.position.z;
        transform.position = _touchPosition;
    }
}
