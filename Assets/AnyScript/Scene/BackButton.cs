using UnityEngine;

public class GameExitButton : MonoBehaviour
{
    // ボタンが押されたら呼ばれる関数
    public void OnClickExit()
    {
        // ログを出して確認できるようにする
        Debug.Log("ゲーム終了ボタンが押されました");

        // Unityエディタで再生している場合
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のアプリ（ビルド後）の場合
        Application.Quit();
#endif
    }
}