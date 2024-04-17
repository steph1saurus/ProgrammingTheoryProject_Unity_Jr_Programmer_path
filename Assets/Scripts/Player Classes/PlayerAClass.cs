using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAClass : BaseClass
{
    private string PlayerAName = "Leprachaun Mames";
    private string PlayerAHeight = "6ft 9in";
    private float ASpeed = 4f;
    private float AShootForce = 5.5f;

    public override string CharacterName { get => PlayerAName; set => PlayerAName = value; }

    public override string CharacterHeight { get => PlayerAHeight; set => PlayerAHeight = value; }

    public override float speed { get =>ASpeed; set => ASpeed = value; }

    public override float shootForce { get => AShootForce; set => AShootForce = value; }

    void Update()
    {
        MovePlayer();
        RotatePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }

    }
}
