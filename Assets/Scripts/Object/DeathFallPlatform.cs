using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFallPlatform : MonoBehaviour, IResetable
{

    public int fallSpeed = 3;
    private bool fallEnter = false;
    public Transform Spawn;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        SingleTonReload.Instance.deathReload.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (fallEnter == true)
        {
            transform.position = transform.position + new Vector3(0, -fallSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fallEnter = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SingleTonReload.Instance.SceneResetAll();
            //SceneReset();
            other.transform.position = Spawn.position;
            fallEnter = false;
        }
    }

    public void SceneReset()
    {
        gameObject.transform.position = originalPos;
    }


}
