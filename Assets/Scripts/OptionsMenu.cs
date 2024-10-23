/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class OptionsMenu : MonoBehaviour
{
    // A button was clicked, go to appropriate menu
    public void OptionButtonClicked()
    {
        // Save name of the selected option and symptom from the first menu
        string option = EventSystem.current.currentSelectedGameObject.name.ToString();
        string symptom = FindObjectOfType<MainMenu>().getButtonName();

        Debug.Log("Symptom: " + symptom);
        Debug.Log("Option: " + option);


    }

    // Play a video for ea symptom.
    public void ReviewProtocol()
    {

    }


    
    public void MeasurePatient()
    {
        SwitchMenus.ChangeMenu(Menu.MEASURE_MENU, gameObject);
    }
    

    public void AdministerMedicine()
    {

    }


    // Back button was clicked, go back to the main menu
    public void BackButtonClicked()
    {
        SwitchMenus.ChangeMenu(Menu.MAIN_MENU, gameObject);
    }
}
*/