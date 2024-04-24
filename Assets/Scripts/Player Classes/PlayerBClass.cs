using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBClass : BaseClass
{

    private string PlayerBName = "Raquille O' Neil";
    private string PlayerBHeight = "7ft 1in";
    private float ASpeed = 4f;
    private float AShootForce = 3.5f;

    public override string CharacterName { get => PlayerBName; set => PlayerBName = value; }

    public override string CharacterHeight { get => PlayerBHeight; set => PlayerBHeight = value; }

    public override float speed { get => ASpeed; set => ASpeed = value; }

    public override float shootForce { get => AShootForce; set => AShootForce = value; }

    void Update()
    {
        if (MainManager.gameActive)
        {
            MovePlayer();
            RotatePlayer();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootBall();
            }
        }

    }

}
