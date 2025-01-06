using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoodController : UnitController

{
    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Mulut")
        {
            List<int> tempRandomIndex = new List<int>()
            {
                2,3,4
            };
            AudioManager.Instance.PlayRandomAudio(tempRandomIndex);
            OnEaten?.Invoke();
            GameObject particleClone = Instantiate(DestroyedParticle.gameObject);
            particleClone.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
