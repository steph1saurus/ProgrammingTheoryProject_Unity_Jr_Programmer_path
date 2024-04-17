using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBase : MonoBehaviour
{
    private string characterName = "Pikachu";
    public virtual string CharacterName
    { get => characterName; set => characterName = value;
       
    }
}

