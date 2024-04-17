using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChildClass : TestBase
{
    private string TestName = "Benny";

    public override string CharacterName { get => TestName; set => TestName = value; }


    private void Update()
    {
        Debug.Log(CharacterName);
    }
}
