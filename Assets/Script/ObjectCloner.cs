using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCloner : MonoBehaviour
{
    #region Variable
    public float MinY;
    public float MaxY;
    public float MinSpeed;
    public float MaxSpeed;
    public float MinDelay;
    public float MaxDelay;

    public GameObject[] ObjectToClone;
    #endregion

    public void CloneObject()
    {
        StartCoroutine(CloneObjectCo());
    }

    public IEnumerator CloneObjectCo()
    {
        while (GameManager.Instance.CurrentGameState == GameState.GamePlay)
        {
            yield return new WaitForSeconds(Random.Range(MinDelay, MaxDelay));

            int index = Random.Range(0, ObjectToClone.Length);

            GameObject Bombclone = Instantiate(ObjectToClone[index]);
            Bombclone.transform.position = new Vector3(-20, Random.Range(MinY, MaxY), 0);
            Bombclone.GetComponent<FoodController>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }
}
