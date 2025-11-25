using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [Header("設定")]
    public string[] targetTags;
    public string nextSceneName = "Title";

    // 物理的な衝突
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("何かにぶつかりました (Collision): " + collision.gameObject.name + " / Tag: " + collision.gameObject.tag);
        CheckTagsAndTransition(collision.gameObject);
    }

    // トリガー（通り抜け）判定
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("何かに重なりました (Trigger): " + other.gameObject.name + " / Tag: " + other.gameObject.tag);
        CheckTagsAndTransition(other.gameObject);
    }

    void CheckTagsAndTransition(GameObject targetObj)
    {
        foreach (string tag in targetTags)
        {
            if (targetObj.CompareTag(tag))
            {
                Debug.Log("タグ [" + tag + "] が一致しました！シーン移動を開始します。");
                ChangeScene();
                return;
            }
        }
        Debug.Log("ぶつかった相手のタグ (" + targetObj.tag + ") はターゲットリストに含まれていません。");
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("シーン名が空です！");
        }
    }
}