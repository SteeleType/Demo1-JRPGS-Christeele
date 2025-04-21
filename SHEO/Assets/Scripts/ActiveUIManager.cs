using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ActiveUIManager : MonoBehaviour
{

    public Button coffeeButton;
    public Button zynButton;
    public Button analysisButton;
    public Button snipeButton;
    public Button synergyButton;
    public GameManagerReal gm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coffeeButton.interactable = false;
        zynButton.interactable = false;
        snipeButton.interactable = false;
        analysisButton.interactable = false;
        synergyButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.internCount >= 2)
        {
            coffeeButton.interactable = true;
        }
        else
        {
            coffeeButton.interactable = false;
        }
        
        if (gm.salesBroCount >= 2)
        {
            zynButton.interactable = true;
        }
        else
        {
            zynButton.interactable = false;
        }
        
        if (gm.managerCount >= 3)
        {
            analysisButton.interactable = true;
        }
        else
        {
            analysisButton.interactable = false;
        }
        
        if (gm.recruiterCount >= 2)
        {
            snipeButton.interactable = true;
        }
        else
        {
            snipeButton.interactable = false;
        }
        
        if (gm.managerCount >= 1
                 && gm.salesBroCount >= 1
                 && gm.managerCount >= 1
                 && gm.internCount >= 1
                 && gm.recruiterCount >= 1)
        {
            synergyButton.interactable = true;
        }
        else
        {
            synergyButton.interactable = false;
        }
        
 
        
    }
}
