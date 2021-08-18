using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle7Handler : PuzzleHandler
{
    [SerializeField]
    private GameObject m_sun;
    private LevelHandler levelHandler;
    private Transform left_gate;
    private Transform right_gate;
    private bool door_opened;
    
    void Start()
    {
        levelHandler=transform.parent.GetComponent<LevelHandler>();
        left_gate = transform.GetChild(0).GetChild(1);
        Debug.Log("left"+left_gate.name);
        right_gate = transform.GetChild(0).GetChild(0);
        door_opened = false;
    }


    void Update()
    {
        if(levelHandler.HasSolvedScene()&&(! door_opened))
        {
            Vector3 left_position = new Vector3(68, -478.84f, 313.77f);
            Vector3 right_position = new Vector3(68, -479, 326);
           left_gate.transform.RotateAround(left_position, Vector3.up,90);
            right_gate.transform.RotateAround(right_position,Vector3.up,90);
            door_opened = true;
            m_sun.SetActive(true);
        }
    }
}
