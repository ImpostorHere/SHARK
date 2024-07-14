using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitController : MonoBehaviour
{
    public float Speed;

    public static event Action OnEaten;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Vector3.left * Time.deltaTime);


        if (transform.position.x > (20))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Mulut")
        {
            OnEaten?.Invoke();
            Destroy(gameObject);
        }
    }
}