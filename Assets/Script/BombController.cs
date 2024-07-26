using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombController : UnitController
{
    public static event Action BombEaten;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BombEaten?.Invoke();
            Destroy(gameObject);
        }
    }
}
