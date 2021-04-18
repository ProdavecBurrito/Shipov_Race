using UnityEngine;
using UnityEngine.EventSystems;

public class TrileController : MonoBehaviour
{

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var kek = Input.touches;
            var vector = kek[0];
        }
    }
}
