using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] public Transform _fireStartPos;
    public GameObject Gun;

    private void Start()
    {
        Gun = GetComponent<GameObject>();
    }

    public void Hide()
    {
        Gun.SetActive(false);
    }

    public void Show()
    {
        Gun.SetActive(true);
    }
}
