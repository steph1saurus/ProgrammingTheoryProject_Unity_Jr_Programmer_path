using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAClass : BaseClass
{
    public PlayerAClass()
    {
        CharacterName = "Leprachaun Mames";
        characterHeight = "6ft 9in";
        characterShootForce = 5.5f;
        characterSpeed = 4f;
    }

    public override float characterSpeed { get => base.characterSpeed; set => base.characterSpeed = value; }

    public override float characterShootForce { get => base.characterShootForce; set => base.characterShootForce = value; }

    
}
