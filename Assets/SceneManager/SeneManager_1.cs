using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class SceneTransitionOnTrigger : MonoBehaviour
{
    // このメソッドは、2Dコライダーがトリガーとして設定されている場合に、
    // 別の2Dコライダーがトリガーに入ったときに呼び出されます。
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 接触したオブジェクトが"Player"タグを持っているか確認します。
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stepタグのオブジェクトに触れました！");
            // "FirstTitleScene"という名前のシーンに遷移します。
            // シーン名はUnityのBuild Settingsに登録されているものと一致させる必要があります。
            SceneManager.LoadScene("GameClear");
        }
    }
}