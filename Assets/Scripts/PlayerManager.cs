using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefabs; //array to hold character prefabs
    private int selectedOption = 0; //index of selected character
    

    void Start()
    {
        // Retrieve the selected character index from saved data (e.g., PlayerPrefs)
        selectedOption = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        // Instantiate the selected character prefab at the spawn point
        InstantiateCharacter();
    }

    void InstantiateCharacter()
    {
        // Check if the selected character index is valid
        if (selectedOption >= 0 && selectedOption < characterPrefabs.Length)
        {
            // Instantiate the selected character prefab at the spawn point
            GameObject selectedCharacter = Instantiate(characterPrefabs[selectedOption], transform.position, Quaternion.identity);
            // Optionally, you can add scripts to control the player, set up UI, etc.
        }
        else
        {
            Debug.LogError("Selected character index is out of range!");
        }
    }
}

