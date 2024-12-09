using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yazdan_Shark
{
    public class StartScreenManager : MonoBehaviour
    {
        public void OnClick_Play()
        {
            SceneManager.LoadScene("Gameplay");
        }

        public void StartGameImmediately() { }
    }
}

