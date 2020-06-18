using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayerScript>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
