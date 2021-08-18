using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PuzzleHandler : MonoBehaviour
{

    protected Transform[] children;

    protected bool isfinished;

    public bool finished()
    {
        return isfinished;
    }

    public virtual void  LoadNextScene()
    {
       
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    protected void completepuzzle()
    {
       
        isfinished = true;
        transform.root.GetComponent<GameRunnerHandler>().hideToolbar();
        Debug.Log(finished());
    }

    private void Awake()
    {
        isfinished = false;
        children = GetComponentsInChildren<Transform>();
        Debug.Log(children[1].tag);
        }

}




