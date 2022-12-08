using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public string objectID;


    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<Spawn>().Length; i++)
        {
            if (Object.FindObjectsOfType<Spawn>()[i] != this)
            {
                if (Object.FindObjectsOfType<Spawn>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
