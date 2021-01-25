using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class CharacterManager : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject characterCreatorScreen;

    public void createNewCharacter()
    {
        homeScreen.SetActive(false);
        characterCreatorScreen.SetActive(true);
        Character character = new Character();
    }

    public void createDwarf()
    {
        
    }
}
