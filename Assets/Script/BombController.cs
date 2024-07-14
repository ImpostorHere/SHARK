using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombController : UnitController
{
    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnEaten?.Invoke();
            Destroy(gameObject);
        }
    }
}
