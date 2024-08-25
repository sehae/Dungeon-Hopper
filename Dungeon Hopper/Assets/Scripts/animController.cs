using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    public GameObject player;  // Reference to the player GameObject
    public GameObject finishMessage;  // Reference to the Finish Message GameObject
    private bool doorOpen = false;  // Track if the door is open

    void Start()
    {
        anim = GetComponent<Animator>();
        finishMessage.SetActive(false);  // Ensure the finish message is hidden at the start
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            anim.SetTrigger("OpenDoor");
            doorOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen && collision.CompareTag("Player"))
        {
            player.SetActive(false);  // Make the player disappear
            Debug.Log("Player entered the door and disappeared.");
            finishMessage.SetActive(true);  // Show the Finish message
        }
    }
}
