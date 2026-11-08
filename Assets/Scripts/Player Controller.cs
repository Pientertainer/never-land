using UnityEngine;
using UnityEngine.InputSystem; // 新しい入力システムを使うために必要

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 120f; // 巨大なフィールドに合わせて120
    private Rigidbody2D _rigidbody2D;
    private Vector2 _inputVector;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 【新方式】キーボードの矢印キーやWASDの入力を直接監視する（エラーが出ない書き方）
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            // WASD または 矢印キー の入力を取得
            float x = 0;
            float y = 0;

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) y = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) y = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1;

            moveInput = new Vector2(x, y).normalized;
        }

        _inputVector = moveInput;
    }

    void FixedUpdate()
    {
        // ログに現在の入力方向を表示（確認用）
        Debug.Log("動いています！入力方向: " + _inputVector);

        // キーボードの入力方向（_inputVector）に向かって移動させる
        Vector2 movement = _inputVector * _speed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
    }
}
