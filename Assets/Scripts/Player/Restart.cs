using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Restart : MonoBehaviour
{
    public Transform Spawn;

    public void OnRestart(InputValue val)
    {
        gameObject.transform.position = Spawn.position;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
