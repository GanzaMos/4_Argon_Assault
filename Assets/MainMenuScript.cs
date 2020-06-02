using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartNewGame", 3);

    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
        Object.DontDestroyOnLoad(GameObject.Find("Music Player"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
