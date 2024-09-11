using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunCD : MonoBehaviour
{
    [SerializeField] private Weapon gunCD;
    [SerializeField] private bool CD;
    [SerializeField] private Slider fireCdImage;

    private void Start()
    {
        CD = gunCD.ShootReady;
        fireCdImage.maxValue = gunCD.Cooldown;
    }

    private void Update()
    {
        
    }
}
