using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefabs; //array to hold character prefabs
    private int selectedCharacterIndex; //index of selected character
    

    void Start()
    {
        // Retrieve the selected character index from saved data (e.g., PlayerPrefs)
        selectedCharacterIndex = PlayerPrefs.GetInt("selectedOption", 0);

        // Instantiate the selected character prefab at the spawn point
        InstantiateCharacter();
    }

    void InstantiateCharacter()
    {
        // Check if the selected character index is valid
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterPrefabs.Length)
        {
            // Instantiate the selected character prefab at the spawn point
            GameObject selectedCharacter = Instantiate(characterPrefabs[selectedCharacterIndex], transform.position, Quaternion.identity);
            // Optionally, you can add scripts to control the player, set up UI, etc.
        }
      
    }
}

