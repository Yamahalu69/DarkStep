using UnityEngine;

public class HideCursorInScene : MonoBehaviour
{
    // シーンが始まった時に呼ばれます
    void Start()
    {
        // カーソルを非表示にする
        Cursor.visible = false;

        // カーソルを画面中央に固定する（非表示中に誤って画面外をクリックしないようにするため）
        // ※完全にマウス操作を無効化したくない場合は、この行を削除しても動きます
        Cursor.lockState = CursorLockMode.Locked;
    }

    // シーンが終了する（次のシーンへ行く）時に呼ばれます
    void OnDestroy()
    {
        // カーソルを再び表示する
        Cursor.visible = true;

        // カーソルの固定を解除する
        Cursor.lockState = CursorLockMode.None;
    }
}