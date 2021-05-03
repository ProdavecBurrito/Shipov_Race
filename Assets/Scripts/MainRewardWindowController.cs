using UnityEngine;
using Tools;

public class MainRewardWindowController : BaseController
{
    private readonly MainRewardWindowView _view;

    public MainRewardWindowController(Transform placeForUI)
    {
        _view = ResourceLoader.LoadAndInstantiateObject<MainRewardWindowView>(new ResourcePath { PathResource = "Prefabs/MainRewardWindow" }, placeForUI, false);
    }
}