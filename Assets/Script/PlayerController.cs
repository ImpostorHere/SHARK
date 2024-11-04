using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joyman;
    public float speed;
    public float rotationSpeed = 1f;
    public int MaxHP = 100;

    public GameObject sharkObj;

    public float clampMinX = -15f;
    public float clampMaxX = 15;

    public float clampMinY = -4.5f;
    public float clampMaxY = 11f;
    public static event Action OnDie;

    /// <summary>
    /// Digunakan untuk menampilkan nilai HP pada karakter saat ini
    /// </summary>
    private int _currentHp;
    private Quaternion _targetRot;
    private Vector3 _dir;

    private void Start()
    {
        _currentHp = MaxHP;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameState.GamePlay)
            return;

        KeyboardControl();

        if (_dir == Vector3.zero)
            JoystickControl();

        MoveCharacter();
    }

    void JoystickControl()
    {
        _dir = new Vector3(-joyman.Direction.x, joyman.Direction.y).normalized;
    }

    void KeyboardControl()
    {
        // Get input for horizontal (A, D) and vertical (W, S) movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow

        // Calculate the movement direction based on input
        _dir = new Vector3(-horizontal, vertical, 0).normalized;
    }

    void MoveCharacter()
    {
        transform.Translate(_dir * speed * Time.deltaTime);

        //Jika arah joystick ke kanan
        if (_dir.x > 0)
        {
            _targetRot = Quaternion.Euler(Vector3.up * 180f);
        }
        //Jika arah joystick ke kiri
        else if (_dir.x < 0)
        {
            _targetRot = Quaternion.Euler(Vector3.zero);
        }

        sharkObj.transform.rotation =
            Quaternion.Slerp(sharkObj.transform.rotation, _targetRot, rotationSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        float clampedPosX = Mathf.Clamp(transform.position.x, clampMinX, clampMaxX);
        float clampedPosY = Mathf.Clamp(transform.position.y, clampMinY, clampMaxY);

        Vector3 clampedPos = new Vector3(clampedPosX, clampedPosY, transform.position.z);

        transform.position = clampedPos;
    }

    public void DecreaseHP(int damage)
    {
        _currentHp -= damage;
        UpdateUI();
        if (_currentHp<=0)
            OnDie?.Invoke();
    }

    /// <summary>
    /// Cuma untuk memanggil fungsi Update punya Game Manager
    /// </summary>
    void UpdateUI()
    {
        GameManager.Instance.UpdateHpBarUI(_currentHp, MaxHP);
    }
}
