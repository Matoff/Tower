using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Debug.Log("teste");
    }

    void Update()
    {
    }   


}
