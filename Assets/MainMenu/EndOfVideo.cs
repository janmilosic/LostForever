using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndOfVideo : MonoBehaviour
{
    public VideoPlayer vid;
    public string NewScene;

    void Start() 
    {
        vid.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Is Over");
        SceneManager.LoadScene(NewScene);
    }
}
