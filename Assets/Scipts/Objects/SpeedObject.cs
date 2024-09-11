using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObject : Object
{
    private int playerSpeed; 
    [SerializeField] private int speed = 2;
    [SerializeField] private int time = 2;

    protected override void PickUp(Rigidbody other)
    {
        print("collide" + other.name);
        if (!other.GetComponent<PlayerController>()) return;
        var player = other.GetComponent<PlayerController>();
        if (player.speedEffect) return;
        print("speed" + other.name);
        playerSpeed = player._moveSpeed;
        player._moveSpeed *= speed;
        player.speedEffect = true;
        StartCoroutine(EffectTime(player));
    }
    private IEnumerator EffectTime(PlayerController player)
    {
        yield return new WaitForSeconds(time);
        player._moveSpeed = playerSpeed;
        player.speedEffect = false;
    }
}
