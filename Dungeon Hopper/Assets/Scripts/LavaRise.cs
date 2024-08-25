using UnityEngine;

public class LavaRise : MonoBehaviour
{
    public float riseSpeed = 2f; // Speed at which the lava rises

    private bool isRising = true; // Flag to control lava rising

    private void Update()
    {
        if (isRising)
        {
            // Move the lava upwards at the specified speed
            transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Stop rising immediately upon contact
            isRising = false;
        }
    }
}
