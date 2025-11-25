using UnityEngine;
using UnityEngine.UI; // UIコンポーネントを扱うために必要

public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f; // 移動速度

    [Header("UIイメージ設定")]
    public Image upArrowImage;    // 上矢印キーに対応するImage
    public Image downArrowImage;  // 下矢印キーに対応するImage
    public Image leftArrowImage;  // 左矢印キーに対応するImage
    public Image rightArrowImage; // 右矢印キーに対応するImage

    [Header("色の設定")]
    public Color pressedColor = new Color(0.5f, 0.5f, 0.5f, 1f); // キーが押されたときの色（濃い灰色）

    // 各Imageの元の色を保存するための変数
    private Color originalUpColor;
    private Color originalDownColor;
    private Color originalLeftColor;
    private Color originalRightColor;

    private Rigidbody2D rb;
    private Vector2 movement;

    // ゲーム開始時に一度だけ呼ばれる
    void Start()
    {
        // Rigidbody 2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();

        // 各UI Imageの元の色を保存しておく
        // nullチェックを入れて、Imageが設定されていなくてもエラーが出ないようにする
        if (upArrowImage != null) originalUpColor = upArrowImage.color;
        if (downArrowImage != null) originalDownColor = downArrowImage.color;
        if (leftArrowImage != null) originalLeftColor = leftArrowImage.color;
        if (rightArrowImage != null) originalRightColor = rightArrowImage.color;
    }

    // フレームごとに毎回呼ばれる
    void Update()
    {
        // --- 移動入力の受付 ---
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D, ←, → キー
        movement.y = Input.GetAxisRaw("Vertical");   // W, S, ↑, ↓ キー

        // --- UIの色変更処理 ---
        HandleUIImageColor();
    }

    // 物理演算のタイミングで呼ばれる
    void FixedUpdate()
    {
        // Rigidbody 2Dを使って物理的に移動させる
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    // UI Imageの色をキー入力に応じて変更するメソッド
    void HandleUIImageColor()
    {
        // 上矢印キー または Wキー
        if (upArrowImage != null)
        {
            // Input.GetKeyは、キーが押されている間ずっとtrueを返す
            // || は「または」を意味する論理OR演算子
            upArrowImage.color = (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) ? pressedColor : originalUpColor;
        }

        // 下矢印キー または Sキー
        if (downArrowImage != null)
        {
            downArrowImage.color = (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? pressedColor : originalDownColor;
        }

        // 左矢印キー または Aキー
        if (leftArrowImage != null)
        {
            leftArrowImage.color = (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) ? pressedColor : originalLeftColor;
        }

        // 右矢印キー または Dキー
        if (rightArrowImage != null)
        {
            rightArrowImage.color = (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) ? pressedColor : originalRightColor;
        }
    }
}