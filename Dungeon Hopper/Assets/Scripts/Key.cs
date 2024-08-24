using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.GetComponent<animController>().PlayAnimation();
            Destroy(gameObject);
            Debug.Log("Key collected!");
            
            
        }
    }
}
