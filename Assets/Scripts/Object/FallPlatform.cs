using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour, IResetable
{

    public int fallSpeed = 3;
    Vector3 originalPos;
    private bool fallEnter = false;

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
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    public void SceneReset()
    {
        gameObject.transform.position = originalPos;
        fallEnter = false;
    }

}
