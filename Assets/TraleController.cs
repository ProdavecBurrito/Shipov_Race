using UnityEngine;

public class TraleController : MonoBehaviour
{
    private Touch _touch;
    private Vector3 _touchPosition;
    private TrailRenderer _trailRenderer;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            DrawTrale();
        }
        else
        {
            _trailRenderer.Clear();
        }
    }

    private void DrawTrale()
    {
        _touch = Input.touches[0];
        _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
        _touchPosition.z = transform.position.z;
        transform.position = _touchPosition;
    }
}
