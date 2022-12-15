using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ReversedKillZone : MonoBehaviour
{
    public Transform firstSpawn;
    public Transform secondSpawn;

    public CameraTrigger ct;
    public PlayerMovement pm;
    public DeathManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!ct.isInSecondRoom)
            {
                other.gameObject.transform.position = firstSpawn.position;
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pm.DisableReverse();
                dm.deathCount++;


                SingleTonReload.Instance.SceneResetAll();

                PlayerPrefs.SetInt("deathCount", PlayerPrefs.GetInt("deathCount") + 1);
            }
            else
            {
                other.gameObject.transform.position = secondSpawn.position;
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pm.DisableReverse();
                dm.deathCount++;

                SingleTonReload.Instance.SceneResetAll();

                PlayerPrefs.SetInt("deathCount", PlayerPrefs.GetInt("deathCount") + 1);
            }            
        }
    }

}
