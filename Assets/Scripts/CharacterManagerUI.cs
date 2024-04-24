using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManagerUI : MonoBehaviour
{
    [SerializeField] CharacterDatabase characterDB; 
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI heightText;
    [SerializeField] Image charImage;

    private int selectedOption = 0; //keeps track which character is selected

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();

        }

        UpdateCharacter(selectedOption);   
    }

    public void NextOption() //allows player to cycle forward through choices
    {
        selectedOption++;

        if(selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0; //if player get to the end of the choices, selected option will go back to number 1
        }

        UpdateCharacter(selectedOption);
        Save();
    }


    public void BackOption() //allows player to cycle backward through choices
    {
        selectedOption--;

        if (selectedOption <0)
        {
            selectedOption = characterDB.characterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        nameText.text = character.characterName;
        heightText.text = character.characterHeight;
        charImage.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption); //Saves the currently selected character option
    }
       

}
