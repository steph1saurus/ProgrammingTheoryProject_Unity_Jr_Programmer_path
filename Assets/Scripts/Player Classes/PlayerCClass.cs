using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCClass : BaseClass
{
   public PlayerCClass()
    {
        CharacterName = "Jichael Mordan";
        characterHeight = "6ft 6in";
        characterShootForce = 5f;
        characterSpeed = 4.5f;
    }
    public override float characterSpeed { get => base.characterSpeed; set => base.characterSpeed = value; }

    public override float characterShootForce { get => base.characterShootForce; set => base.characterShootForce = value; }
}
