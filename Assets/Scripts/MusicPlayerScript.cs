using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(GameObject.Find("Music Player"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
