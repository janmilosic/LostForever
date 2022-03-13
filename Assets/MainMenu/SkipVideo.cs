using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{

    public string NewSceneName;

    public void Skip()
    {
        SceneManager.LoadScene(NewSceneName);
    }
}
