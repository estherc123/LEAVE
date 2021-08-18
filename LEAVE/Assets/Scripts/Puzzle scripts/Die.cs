using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    PuzzleHandler puzzle;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = transform.parent.gameObject;
        while (!obj.CompareTag("Puzzle Handler"))
            obj = obj.transform.parent.gameObject;

        puzzle = obj.GetComponent<PuzzleHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("PuzzleObject"))
        {
            puzzle.LoadCurrentScene();
        }
    }

}
