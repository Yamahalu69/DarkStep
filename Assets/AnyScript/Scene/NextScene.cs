using UnityEngine;
using UnityEngine.SceneManagement; // シーン遷移に必須

public class ButtonSceneChanger : MonoBehaviour
{
    [Header("設定")]
    [Tooltip("移動先のシーン名をここに入力してください")]
    public string nextSceneName;

    // ボタンの OnClick イベントに登録するメソッド
    public void OnClickButton()
    {
        // シーン名が設定されているか確認
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("シーン名が空です！Inspectorで設定してください。");
        }
    }
}