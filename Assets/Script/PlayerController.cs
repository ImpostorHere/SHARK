using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameState.GamePlay)
            return;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //NaikKeAtas
            MoveVertical(true);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //NaikKeBawah
            MoveVertical(false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //MinggirKeKiri
            isFacingRight = false;
            MoveHorisontal();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //MinggirKeKanan
            isFacingRight = true;
            MoveHorisontal();
        }
    }
    void MoveVertical(bool Upward)
    {
        if(Upward==true)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else 
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
    void MoveHorisontal()
    {
        if(isFacingRight==true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
