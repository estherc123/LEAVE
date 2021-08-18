using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    PuzzleHandler puzzleHandler;
    GameObject puzzle;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = transform.parent.gameObject;
        while (!puzzle.CompareTag("Puzzle Handler"))
            puzzle = puzzle.transform.parent.gameObject;
        Debug.Log(puzzle.name);
        puzzleHandler = puzzle.GetComponent<PuzzleHandler>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("PuzzleObject"))
        {
            Instantiate((GameObject)Resources.Load("Prefabs/Physics Puzzle2/Triggers", typeof(GameObject)));
            for (int i = 0; i < puzzle.transform.childCount; i++)
            {
                if (puzzle.transform.GetChild(i).name == "Die")
                {
                    Destroy(puzzle.transform.GetChild(i).gameObject );
                }
            }
        }
       
    }
}
