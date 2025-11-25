using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionOnTrigger : MonoBehaviour
{
    [Header("遷移先の設定")]
    [Tooltip("移動したいシーンの名前をここに入力してください")]
    public string nextSceneName; // Inspectorで変更できる変数

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 接触したオブジェクトが"Player"タグを持っているか確認
        if (other.CompareTag("Player"))
        {
            // シーン名が空でないかチェック
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                Debug.Log("シーン遷移を開始します: " + nextSceneName);
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("シーン名が設定されていません！Inspectorを確認してください。");
            }
        }
    }
}