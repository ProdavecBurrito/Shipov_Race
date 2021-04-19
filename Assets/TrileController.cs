using UnityEngine;

public class TrileController : MonoBehaviour
{
    // Можете подсказать, как это можно улучшить? Мне кажется, это колхозный способ.
    // (про Update и тд я сам понимаю, просто делал, что бы хоть как то работало).
    // Проблемма в том, что если просто написать Camera.main.ScreenToWorldPoint(touch.position)
    // То сей обьект будет по Z уходить на координаты камеры (которые -15)
    // И изза этого трайл не видно
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
        }
    }
}
