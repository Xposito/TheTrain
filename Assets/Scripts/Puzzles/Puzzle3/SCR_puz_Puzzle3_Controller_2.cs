using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle3_Controller_2 : MonoBehaviour
{
    [Header(" ")]
    public Transform[] positions;
    public GameObject[] lights;
    public GameObject trigger;

    [Header("Player")]
    public GameObject player;
    public Transform playerInitialPosition;

    [Header(" ")]
    public int position;

    public float timer;
    public float maxTimeForPlayer;
    public float maxTimeForEnemy;

    public bool playerTurn;
    public bool playerDead;
    public bool playerWon;

    public Rigidbody rb;


    private void Start()
    {
        RestartPuzzle();
        rb = player.GetComponentInParent<Rigidbody>();
    }


    private void Update()
    {
        if (playerDead) return;
        if (playerWon) return;

        timer -= Time.deltaTime;

        //Player has to run. Turn off the light
        if(playerTurn && timer > 0)
        {
            TurnOffLIghts();
        }

        //Player has to stop. Lights turn on
        if(timer <= 0 && playerTurn)
        {
            position++;
            NextTriggerPos();
            MaxEnemyTime();
            playerTurn = false;
        }

        //Player has to stay still and learn the path
        if (!playerTurn && timer > 0)
        {
            TurnOnLIghts();
            CheckForMovement();
        }

        //Player can run again
        if (timer <= 0 && !playerTurn)
        {
            MaxPlayerTime();
            playerTurn = true;
        }
    }


    void RestartPuzzle()
    {
        position = 0;
        playerTurn = true;
        MaxPlayerTime();
        playerDead = false;
        playerWon = false;
        NextTriggerPos();
    }

    void TurnOffLIghts()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].gameObject.SetActive(false);
        }
    }

    void TurnOnLIghts()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].gameObject.SetActive(true);
        }
    }

    void MaxPlayerTime()
    {
        timer = maxTimeForPlayer;
    }

    void MaxEnemyTime()
    {
        timer = maxTimeForEnemy;
    }

    void NextTriggerPos()
    {
        trigger.transform.position = positions[position].position;
    }

    public void KillPlayer()
    {
        player.transform.position = playerInitialPosition.position;
        Debug.Log("You died :(");
        RestartPuzzle();
    }

    public void Win()
    {
        Debug.Log("You won :)");
        playerWon = true;
    }

    void CheckForMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput != 0 && verticalInput != 0)
        {
            KillPlayer();
        }
    }


}
