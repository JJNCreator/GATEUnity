using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _versionText;
    // Start is called before the first frame update
    void Start()
    {
        _versionText.text = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayGameClicked()
    {
        PlayGame().Forget();
    }

    #region editor-bound
    public async UniTask PlayGame()
    {
        var loadScene = SceneManager.LoadSceneAsync(1);
        while(!loadScene.isDone)
        {
            await UniTask.Yield();
        }
    }
    public void OnQuitGameCLicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion
}
