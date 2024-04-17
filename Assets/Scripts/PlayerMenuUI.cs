using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMenuUI : MonoBehaviour
{


    [SerializeField]    TextMeshProUGUI nameText;
    [SerializeField]    TextMeshProUGUI heightText;
    [SerializeField]    GameObject playerImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnPlayerAClicked()//Player A
    {
        nameText.text = "Leprachaun Mames";
        heightText.text = "6ft 9in";
        
    }
        
    public void OnPlayerBClicked() //Player B
    {
        
        nameText.text = "Raquille O' Neil";
        heightText.text = "7ft 1in";
    }

    public void OnPlayerCClicked() //Player C
    {
        nameText.text = "Jichael Mordan";
        heightText.text = "6ft 6in";
    }
}
