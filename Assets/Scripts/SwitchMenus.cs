using JetBrains.Annotations;
using UnityEngine;

public static class SwitchMenus
{
    public static bool Initialised { get; private set; }
    public static GameObject mainMenu, weightMenu, measureMenu, ageMenu, medicationMenu, 
                            barcodeMenu, unableToScanMenu, administerMenu, bloodSugarLevelMenu, finalMenu;

    // Initalize the objects
    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("Main Menu").gameObject;
        weightMenu = canvas.transform.Find("Weight Menu").gameObject;
        measureMenu = canvas.transform.Find("Measure Menu").gameObject;
        ageMenu = canvas.transform.Find("Age Menu").gameObject;
        medicationMenu = canvas.transform.Find("Medication Menu").gameObject;
        barcodeMenu = canvas.transform.Find("Barcode Menu").gameObject;
        unableToScanMenu = canvas.transform.Find("Unable To Scan Menu").gameObject;
        administerMenu = canvas.transform.Find("Administer Menu").gameObject;
        bloodSugarLevelMenu = canvas.transform.Find("Blood Sugar Level Menu").gameObject;
        finalMenu = canvas.transform.Find("Final Menu").gameObject;
    }

    // Change visibility of the menus
    public static void ChangeMenu(Menu menu, GameObject menuToClose)
    {
        if (!Initialised)
        {
            Init();
        }

        // Control which menu to open
        switch(menu)
        {
            case Menu.MAIN_MENU:
                if (!mainMenu.activeSelf)
                {
                    mainMenu.SetActive(true);
                    menuToClose.SetActive(false);
                    // Change the color of "Condition" to orange on the progress bar
                    ProgressBarController.changeProgressColor("Condition");
                }
                break;

            case Menu.WEIGHT_MENU:
                if (!weightMenu.activeSelf)
                {
                    weightMenu.SetActive(true);
                    menuToClose.SetActive(false);
                    // Change the color of "weight" to orange on the progress bar
                    ProgressBarController.changeProgressColor("Weight");
                }
                break;

            case Menu.MEASURE_MENU:
                if (!measureMenu.activeSelf)
                {
                    measureMenu.SetActive(true);
                    menuToClose.SetActive(false);
                }
                break;

            case Menu.AGE_MENU:
                if (!ageMenu.activeSelf)
                {
                    ageMenu.SetActive(true);
                    menuToClose.SetActive(false);
                }
                break;

            case Menu.MEDICATION_MENU:
                if (!medicationMenu.activeSelf)
                {
                    medicationMenu.SetActive(true);
                    menuToClose.SetActive(false);
                    // Change the color of "medication" to orange on the progress bar
                    ProgressBarController.changeProgressColor("Medication");
                }
                break;

            case Menu.BARCODE_MENU:
                if (!barcodeMenu.activeSelf)
                {
                    barcodeMenu.SetActive(true);
                    menuToClose.SetActive(false);
                    // Change the color of "Dose" to orange on the progress bar
                    ProgressBarController.changeProgressColor("Dose");
                }
                break;

            case Menu.UNABLE_TO_SCAN_MENU:
                if (!unableToScanMenu.activeSelf)
                {
                    unableToScanMenu.SetActive(true);
                    menuToClose.SetActive(false);
                }
                break;


            case Menu.ADMINISTER_MENU:
                if (!administerMenu.activeSelf)
                {
                    administerMenu.SetActive(true);
                    menuToClose.SetActive(false);
                    // Change the color of "Administer" to orange on the progress bar
                    ProgressBarController.changeProgressColor("Administer");
                }
                break;

            case Menu.BLOOD_SUGAR_LEVEL_MENU:
                if (!bloodSugarLevelMenu.activeSelf)
                {
                    bloodSugarLevelMenu.SetActive(true);
                    menuToClose.SetActive(false);
                }
                break;

            case Menu.FINAL_MENU:
                if (!finalMenu.activeSelf)
                {
                    finalMenu.SetActive(true);
                    menuToClose.SetActive(false);
                }
                break;
        }

       
    }
}

