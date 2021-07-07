using UnityEngine;

public class GunView : MonoBehaviour
{
    public Transform _fireStartPos;
    [SerializeField] private GameObject _fireObjects;
    [SerializeField] private GameObject _gun;
    public GameObject Gun => _gun;
    public GameObject FireObjects => _fireObjects;

    public void Hide()
    {
        Gun.SetActive(false);
    }

    public void Show()
    {
        Gun.SetActive(true);
    }
}
