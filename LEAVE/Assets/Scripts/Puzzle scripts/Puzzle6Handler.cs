using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Puzzle6Handler : PuzzleHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void LoadNextScene()
    {
        SceneManager.UnloadSceneAsync("Physics-based2");
        SceneManager.GetSceneByName("Level2").GetRootGameObjects()[0].transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
