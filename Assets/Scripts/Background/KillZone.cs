using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform Spawn;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = Spawn.position;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            PlayerPrefs.SetInt("deathCount", PlayerPrefs.GetInt("deathCount", 0) + 1);
            
        }
    }

}
