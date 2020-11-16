using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int Money { get; private set; }

    private void Awake()
    {
        instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
