using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCClass : BaseClass
{
 
    public override string CharacterName { get => base.CharacterName; set => base.CharacterName = "Jichael Mordan"; }

    public override string CharacterHeight { get => base.CharacterHeight; set => base.CharacterHeight = "6ft 6in"; }

    public override float characterSpeed { get => base.characterSpeed; set => base.characterSpeed = 5f; }

    public override float characterShootForce { get => base.characterShootForce; set => base.characterShootForce = 4.5f; }
}
