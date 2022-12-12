using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingleTonReload : MonoBehaviour
{
    private static SingleTonReload instance = null;
    public static SingleTonReload Instance => instance;

    //public GameObject deathRld;
    public List<IResetable> deathReload = new();
    int deathReloadSize;

    public void Awake()
    {
        instance = this;
    }

    public void SceneResetAll()
    {
        foreach (IResetable item in Instance.deathReload)
        {
            item.SceneReset();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
