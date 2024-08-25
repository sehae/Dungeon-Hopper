using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour
{
    public float riseSpeed = 2f;  // Speed at which the lava rises

    // Update is called once per frame
    void Update()
    {
        // Move the lava upwards at the specified speed
        transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);
    }
}
