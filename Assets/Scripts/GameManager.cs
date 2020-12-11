using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    // secret settings
    public bool infiniteMode = false;

    private void Awake()
    {
        if (GameManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TriggerSecretMode()
    {
        infiniteMode = !infiniteMode;
        Debug.Log("Infinite Mode: " + infiniteMode.ToString());
    }
}
