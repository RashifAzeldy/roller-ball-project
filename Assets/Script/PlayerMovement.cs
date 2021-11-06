using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 moveDirection = new Vector3(h * moveSpeed * Time.deltaTime,
                0, v * moveSpeed * Time.deltaTime);

            transform.Translate(moveDirection);
        }
    }
}
