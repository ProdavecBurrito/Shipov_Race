using UnityEngine;

public class TrileController : MonoBehaviour
{
    // ������ ����������, ��� ��� ����� ��������? ��� �������, ��� ��������� ������.
    // (��� Update � �� � ��� �������, ������ �����, ��� �� ���� ��� �� ��������).
    // ��������� � ���, ��� ���� ������ �������� Camera.main.ScreenToWorldPoint(touch.position)
    // �� ��� ������ ����� �� Z ������� �� ���������� ������ (������� -15)
    // � ���� ����� ����� �� �����
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
        }
    }
}
