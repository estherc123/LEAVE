using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class EnemyScript : MonoBehaviour
 {
 
     public Transform Player;
    public GameRunnerHandler handler;

    [SerializeField]
     public int MoveSpeed = 6;
     private readonly int MaxDist = 10;
     private readonly int minDist = 4;
 

 
     void Start()
     {
     }
 
     void Update()
     {

        if (Vector3.Distance(transform.position, Player.position) >= minDist)
         {
            transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
        else if (Vector3.Distance(transform.position, Player.position) <= 2)
        {
            Debug.Log("game over");
            handler.gameOver();
        }
    }
 }