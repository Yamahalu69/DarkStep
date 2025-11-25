using UnityEngine;

public class SceneCursorController : MonoBehaviour
{
    // シーンが始まった（このオブジェクトがロードされた）時に呼ばれます
    void Start()
    {
        // カーソルを表示する
        Cursor.visible = true;

        // カーソルのロックを解除する（画面内で自由に動かせるようにする）
        Cursor.lockState = CursorLockMode.None;
    }

    // シーンが終了する（このオブジェクトが破棄される）時に呼ばれます
    void OnDestroy()
    {
        // カーソルを非表示に戻す
        Cursor.visible = false;

        // 必要であればカーソルをロックする（FPS視点やアクションゲーム等の場合）
        // 特にロックが必要ない場合は、この行は削除しても構いません
        Cursor.lockState = CursorLockMode.Locked;
    }
}