using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joyman;
    public float speed;
    public float rotationSpeed = 1f;
    public int MaxHP = 100;

    public GameObject sharkObj;

    /// <summary>
    /// Digunakan untuk menampilkan nilai HP pada karakter saat ini
    /// </summary>
    int _currentHp;
    Quaternion _targetRot;

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

        Vector3 dir = new Vector3(-joyman.Direction.x, joyman.Direction.y);
        transform.Translate(dir * speed * Time.deltaTime);

        //Jika arah joystick ke kanan
        if(dir.x > 0)
        {
            _targetRot = Quaternion.Euler(Vector3.up * 180f);
        }
        //Jika arah joystick ke kiri
        else if(dir.x < 0)
        {
            _targetRot = Quaternion.Euler(Vector3.zero);
        }

        sharkObj.transform.rotation = 
            Quaternion.Slerp(sharkObj.transform.rotation, _targetRot, rotationSpeed * Time.deltaTime);
    }

    public void DecreaseHP(int damage)
    {
        _currentHp -= damage;
        UpdateUI();
    }

    /// <summary>
    /// Cuma untuk memanggil fungsi Update punya Game Manager
    /// </summary>
    void UpdateUI()
    {
        GameManager.Instance.UpdateHpBarUI(_currentHp, MaxHP);
    }
}
