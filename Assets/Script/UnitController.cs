using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitController : MonoBehaviour
{
    public float Speed;

    public static Action OnEaten;

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Speed * Vector3.left * Time.deltaTime);
        transform.position += Speed * Vector3.left * Time.deltaTime;

        if (transform.position.x > (20))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Mulut")
        {
            collision.transform.parent.parent.GetComponent<PlayerController>().DecreaseHP(10);
            OnEaten?.Invoke();
            Destroy(gameObject);
        }
    }
}