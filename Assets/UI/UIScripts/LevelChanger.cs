using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    
    public Animator animator;
    public GameObject transitionPanel;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transitionPanel.SetActive(true);
            animator.SetTrigger("StartTransition");
            Time.timeScale= 0.0f;
        }
    }
}
