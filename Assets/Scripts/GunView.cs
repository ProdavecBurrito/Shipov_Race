using UnityEngine;

public class GunView : MonoBehaviour
{
    public Transform _fireStartPos;
    [SerializeField] private GameObject _fireObjects;
    public GameObject Gun { get; private set; }
    public GameObject FireObjects => _fireObjects;

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
