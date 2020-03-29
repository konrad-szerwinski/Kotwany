using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoChangeToScene : MonoBehaviour {
    //zmienne globalne
    private VideoPlayer videoPlayer;
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        videoPlayer.Play();
    }

    //jeśli film się skończy, zostaje załadowana kolejna scena;
    void Update () {
        if ((ulong)videoPlayer.frame == (ulong)videoPlayer.frameCount)
        {
            Debug.Log("Video Ended");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        
    }
}
