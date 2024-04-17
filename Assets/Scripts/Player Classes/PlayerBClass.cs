using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBClass : BaseClass
{
   public PlayerBClass()
    {
        CharacterName = "Raquille O' Neil";
        characterHeight = "7ft 1in";
        characterShootForce = 5.5f;
        characterSpeed = 3.5f;
    }
    public override float characterSpeed { get => base.characterSpeed; set => base.characterSpeed = value; }

    public override float characterShootForce { get => base.characterShootForce; set => base.characterShootForce = value; }

}
