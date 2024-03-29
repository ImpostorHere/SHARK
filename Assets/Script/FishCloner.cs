using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCloner : MonoBehaviour
{
    public static FishCloner Instance;

    #region Variable
    public float MinY;
    public float MaxY;
    public float MinSpeed;
    public float MaxSpeed;

    [Header("FishVariation")]
    public GameObject FishA;
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloneFish()
    {
        StartCoroutine(CloneFishCo());
    }

    public IEnumerator CloneFishCo()
    {
        while (GameManager.Instance.CurrentGameState == GameState.GamePlay)
        {
            yield return new WaitForSeconds(Random.Range(0.125f, 1));           

            GameObject Fishclone = Instantiate(FishA);
            Fishclone.transform.position = new Vector3(-20, Random.Range(MinY, MaxY), 0);
            Fishclone.GetComponent<FoodController>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }
}
