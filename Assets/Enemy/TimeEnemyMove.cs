using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TimeEnemyEffect : MonoBehaviour
{
    [Header("判定の設定")]
    [Tooltip("実際にプレイヤーが遅くなる範囲（当たり判定）")]
    public float logicRadius = 3.0f;

    [Tooltip("範囲内に入った時のプレイヤーの速度")]
    public float slowSpeed = 2.0f;

    [Header("見た目の設定")]
    [Tooltip("ゲーム画面に描画される円の大きさ（当たり判定とは無関係）")]
    public float visualRadius = 3.0f;

    public Color circleColor = new Color(1f, 0f, 0f, 0.5f);
    public float lineWidth = 0.1f;

    // 内部変数
    private GameObject playerObj;

    // ↓↓↓ あなたのプレイヤースクリプト名に書き換えてください ↓↓↓
    private PlayerController playerScript;
    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    private float defaultSpeed;
    private bool isSlowed = false;
    private LineRenderer lineRenderer;
    private int segments = 50;

    void Start()
    {
        // --- プレイヤー取得 ---
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            // ↓↓↓ ここも書き換えが必要です ↓↓↓
            playerScript = playerObj.GetComponent<PlayerController>();

            if (playerScript != null)
            {
                defaultSpeed = playerScript.moveSpeed;
            }
        }

        // --- LineRenderer初期化 ---
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update()
    {
        // 1. 見た目の更新（Visual Radius を使用）
        UpdateCircleVisual();

        // 2. プレイヤーへの効果処理（Logic Radius を使用）
        if (playerScript == null) return;

        float distance = Vector2.Distance(transform.position, playerObj.transform.position);

        // ★ここで判定用の半径を使用
        if (distance <= logicRadius)
        {
            if (!isSlowed)
            {
                playerScript.moveSpeed = slowSpeed;
                isSlowed = true;
            }
        }
        else
        {
            if (isSlowed)
            {
                playerScript.moveSpeed = defaultSpeed;
                isSlowed = false;
            }
        }
    }

    // 円を描画する関数
    void UpdateCircleVisual()
    {
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = circleColor;
        lineRenderer.endColor = circleColor;
        lineRenderer.positionCount = segments;

        for (int i = 0; i < segments; i++)
        {
            float angle = 2 * Mathf.PI * i / segments;

            // ★ここで見た目用の半径を使用
            float x = Mathf.Sin(angle) * visualRadius;
            float y = Mathf.Cos(angle) * visualRadius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    // エディタ確認用 (Gizmos)
    void OnDrawGizmosSelected()
    {
        // 黄色い線 = 実際の当たり判定
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, logicRadius);

        // 白い線 = 見た目の円（赤い円が表示される場所）
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, visualRadius);
    }
}