using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCloner : MonoBehaviour
{
    public static BombCloner Instance;

    #region Variable
    public float MinY;
    public float MaxY;
    public float MinSpeed;
    public float MaxSpeed;
    public float MinDelay;
    public float MaxDelay;

    public GameObject[] Bomb;
    #endregion

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloneBomb()
    {
        StartCoroutine(CloneBombCo());
    }

    public IEnumerator CloneBombCo()
    {
        while (GameManager.Instance.CurrentGameState == GameState.GamePlay)
        {
            yield return new WaitForSeconds(Random.Range(MinDelay, MaxDelay));

            int index = Random.Range(0, 4);

            GameObject Bombclone = Instantiate(Bomb[index]);
            Bombclone.transform.position = new Vector3(-20, Random.Range(MinY, MaxY), 0);
            Bombclone.GetComponent<FoodController>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }
}
