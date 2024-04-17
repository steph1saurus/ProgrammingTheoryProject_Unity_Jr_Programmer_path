using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAClass : BaseClass
{


    public override string CharacterName { get => base.CharacterName; set => base.CharacterName = "Leprachaun Mames"; }

    public override string CharacterHeight { get => base.CharacterHeight; set => base.CharacterHeight = "6ft 9in"; }

    public override float characterSpeed { get => base.characterSpeed; set => base.characterSpeed = 4f; }

    public override float characterShootForce { get => base.characterShootForce; set => base.characterShootForce = 5.5f; }

    
}
