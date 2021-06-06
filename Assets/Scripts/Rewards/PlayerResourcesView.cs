using TMPro;
using UnityEngine;

public class PlayerResourcesView : MonoBehaviour
{
    public static PlayerResourcesView Instance;

    private const string IronKey = nameof(IronKey);
    private const string ToolsKey = nameof(ToolsKey);

    [SerializeField] private TMP_Text _currentIronValue;
    [SerializeField] private TMP_Text _currentToolsValue;

    private int Iron
    {
        get => PlayerPrefs.GetInt(IronKey, 0);
        set => PlayerPrefs.SetInt(IronKey, value);
    }
    private int Tools
    {
        get => PlayerPrefs.GetInt(ToolsKey, 0);
        set => PlayerPrefs.SetInt(ToolsKey, value);
    }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshText();
    }

    public void AddIron(int value)
    {
        Debug.Log(value);
        Iron += value;
        RefreshText();
    }
    public void AddTools(int value)
    {
        Tools += value;
        RefreshText();
        Debug.Log(value);
    }
    private void RefreshText()
    {
        _currentIronValue.text = Iron.ToString();
        _currentToolsValue.text = Tools.ToString();
    }

}
