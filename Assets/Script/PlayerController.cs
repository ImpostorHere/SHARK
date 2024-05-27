using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joyman;
    public float speed;
    public float rotationSpeed = 1f;

    public GameObject sharkObj;

    Quaternion _targetRot;

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

        sharkObj.transform.rotation = Quaternion.Slerp(sharkObj.transform.rotation, _targetRot, rotationSpeed * Time.deltaTime);
    }
}
