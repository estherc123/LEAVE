using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Puzzle9Handler : PuzzleHandler
{
    // Start is called before the first frame update
    #region Private Variables
    private GameObject sball1;
    private GameObject sball2;
    private GameObject sball3;
    private GameObject sball4;
    private GameObject disappear;
    private GameObject sudokuBox;
    #endregion
    void Start()
    {
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "Ball1 (1)")
            {
                sball1 = children[i].gameObject;
            }
            if (children[i].name == "SudokuBall")
            {
                sball2 = children[i].gameObject;
            }
            if (children[i].name == "SudokuBall2")
                sball3 = children[i].gameObject;
            if (children[i].name == "Ball4")
                sball4 = children[i].gameObject;
            
            if (children[i].name == "Disappear")
            {
               disappear = children[i].gameObject;
            }
            if (children[i].name == "SudokuBox")
                sudokuBox = children[i].gameObject;

        }
        
    }
    public override void LoadNextScene()
    {
        SceneManager.UnloadSceneAsync("Physics-based3");
        SceneManager.GetSceneByName("Level2").GetRootGameObjects()[0].transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (finished() != true)
        {
            
            if (
                
                sball1.GetComponent<PuzzleObjectHandler>().getMaterial().Equals("paper")&&
                sball2.GetComponent<PuzzleObjectHandler>().getMaterial().Equals("copper") &&
                sball3.GetComponent<PuzzleObjectHandler>().getMaterial().Equals("wood") &&
                sball4.GetComponent<PuzzleObjectHandler>().getMaterial().Equals("gold"))
            {
                Debug.Log("here");
                Destroy(disappear);
                completepuzzle();
            }
                
        }
    }
}
