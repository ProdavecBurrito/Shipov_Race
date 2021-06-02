using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleLoader : MonoBehaviour
{
    private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=11zpUPvidBi4bioslI4h67fpabsIHCPKP";

    [SerializeField] DataObjectBundle _dataObjectBundle;
    private AssetBundle _spritesAssetBundle;

    public DataObjectBundle CarBundle => _dataObjectBundle;

    public void Awake()
    {
        StartCoroutine(DownloadAndSetAssetBundle());
    }

    private IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();

        if (_spritesAssetBundle == null)
        {
            Debug.LogError($"AssetBundle {_spritesAssetBundle} failed to load");
            yield break;
        }

        SetDownloadAssets();
        yield return null;
    }

    private IEnumerator GetSpritesAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null;
        }

        StateRequest(request, ref _spritesAssetBundle);
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete");
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    private void SetDownloadAssets()
    {
        Debug.Log(_dataObjectBundle.LoadingObject);
        _dataObjectBundle.LoadingObject = _spritesAssetBundle.LoadAsset<GameObject>(_dataObjectBundle.NameAssetBundle);
    }
}

