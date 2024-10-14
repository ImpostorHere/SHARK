using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : UnitController
{
    public float RandomX;
    public float RandomY;
    public float RandomZ;
    public Transform particle;
    protected override void Start()
    {
        base.Start();
        particle.parent = null;
        RandomX = Random.Range(0, 360);
        RandomY = Random.Range(0, 360);
        RandomZ = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(RandomX, RandomY, RandomZ);
        particle.parent = this.transform;
    }
    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent.parent.GetComponent<PlayerController>().DecreaseHP(10);
            Destroy(gameObject);
        }
    }
}
