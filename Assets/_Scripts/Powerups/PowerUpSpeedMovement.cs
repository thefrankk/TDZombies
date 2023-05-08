using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedMovement : PowerUp
{
    protected override void applyPowerUp(Player player)
    {
        Debug.Log("Do stuff with player...");
    }

    protected override void stopPowerUp()
    {
        Debug.Log("Stopped");
    }
}
