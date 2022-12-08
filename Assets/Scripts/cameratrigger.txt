using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstCam;
    [SerializeField] private CinemachineVirtualCamera secondCam;

    BoxCollider2D bc;

    public bool isInSecondRoom = false;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();    
    }

    private void OnEnable()
    {
        CameraSwitcher.Register(firstCam);
        CameraSwitcher.Register(secondCam);
        CameraSwitcher.SwitchCamera(firstCam);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(firstCam);
        CameraSwitcher.Unregister(secondCam);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (CameraSwitcher.IsActiveCamera(firstCam))
            {
                CameraSwitcher.SwitchCamera(secondCam);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bc.isTrigger = false;
            isInSecondRoom = true;
        }
    }
}
