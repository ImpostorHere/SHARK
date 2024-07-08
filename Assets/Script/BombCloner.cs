using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCloner : ObjectCloner
{
    public static BombCloner Instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
}
