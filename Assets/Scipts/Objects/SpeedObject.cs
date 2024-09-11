using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObject : Object
{
    private int playerSpeed; 
    [SerializeField] private int speed;
    [SerializeField] private int time;

    protected override void PickUp(Collider other)
    {
        if (!other.GetComponent<PlayerController>()) return;
        var player = other.GetComponent<PlayerController>();
        if (player.speedEffect) return;
        playerSpeed = player._moveSpeed;
        player._moveSpeed = speed;
        player.speedEffect = true;
        
    }

    private IEnumerator EffectTime(PlayerController player)
    {
        yield return new WaitForSeconds(time);
        player._moveSpeed = playerSpeed;
        player.speedEffect = false;
    }
}
