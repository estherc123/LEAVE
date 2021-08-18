using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    // Start is called before the first frame update
    PuzzleHandler puzzle;
    LevelHandler levelHandler;
    void Start()
    {
        GameObject obj = transform.parent.gameObject;
        while (!obj.CompareTag("Puzzle Handler"))
            obj = obj.transform.parent.gameObject;

        puzzle = obj.GetComponent<PuzzleHandler>();

        Transform obj2 = transform.root;
        for(int i=0; i<obj2.childCount; i++)
        {
            if (obj2.GetChild(i).name == "Level")
                obj2 = obj2.GetChild(i);
        }
        levelHandler = obj2.GetComponent<LevelHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        if(other.CompareTag("PuzzleObject"))
        {
            
            levelHandler.SolveScene();
            puzzle.LoadNextScene();
        }
    }

}
