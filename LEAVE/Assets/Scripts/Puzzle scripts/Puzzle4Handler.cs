using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Puzzle4Handler :PuzzleHandler
{
    
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   



    public override void LoadNextScene()
    {
        SceneManager.UnloadSceneAsync("Physics-based Puzzle");
        SceneManager.GetSceneByName("Level2").GetRootGameObjects()[0].transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
}
