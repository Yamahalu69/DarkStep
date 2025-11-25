using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [Header("設定")]
    [Tooltip("追いかける速度")]
    public float speed = 3.0f;

    [Tooltip("プレイヤーを検知する半径")]
    public float detectionRadius = 5.0f;

    [Tooltip("一度見つけたら、距離が離れても追いかけ続けるか？")]
    public bool keepChasingOnceSeen = true;

    // 内部変数
    private Transform playerTransform;
    private bool isChasing = false; // 今追いかけているかどうか

    void Start()
    {
        // シーン内から "Player" タグを持つオブジェクトを探しておく
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Playerタグを持つオブジェクトが見つかりません！");
        }
    }

    void Update()
    {
        // プレイヤーがいなければ何もしない
        if (playerTransform == null) return;

        // 敵とプレイヤーの距離を計算
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        // 1. まだ追いかけていない場合：範囲内かチェック
        if (!isChasing)
        {
            if (distance <= detectionRadius)
            {
                isChasing = true; // 追跡モードON
            }
        }

        // 2. 追いかけている場合：移動処理
        if (isChasing)
        {
            // プレイヤーの方向へ移動する
            transform.position = Vector2.MoveTowards(
                transform.position,
                playerTransform.position,
                speed * Time.deltaTime
            );

            // もし「一度見つけたら追いかけ続ける」設定がオフの場合、
            // 距離が離れたら追跡をやめる処理（必要に応じて）
            if (!keepChasingOnceSeen && distance > detectionRadius)
            {
                isChasing = false;
            }
        }
    }

    // Unityエディタ上で検知範囲を可視化するための機能
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        // 検知範囲を黄色い円で描画
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}