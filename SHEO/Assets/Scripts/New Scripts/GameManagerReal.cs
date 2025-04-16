using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManagerReal : MonoBehaviour
{
    //variables of how many of each you own
    
    public int managerCount;
    public int recruiterCount;
    public int salesBroCount;
    public int internCount;
    public int maxEmployees;
    public int playerMorale;
    public int maxHealth;
    public TextMeshProUGUI playerMoraleText;

    public GameObject mainMenu;

    public float spacing = 25f;
    
    //different prefabs for employee types
    public GameObject managerPrefab;
    public GameObject salesBroPrefab;
    public GameObject internPrefab;
    public GameObject recruiterPrefab;
    
    //different prefabs for different transforms
    public Transform managerTransform;
    public Transform salesBroTransform;
    public Transform internTransform;
    public Transform recruiterTransform;
    
    
    // //properties to hopefully update when called with the current counts
    // public int ManagerCount
    // {
    //     set
    //     {
    //         managerCount = value;
    //         UpdateTotal();
    //         Debug.Log(managerCount);
    //     }
    //     get
    //     {
    //         return managerCount;
    //         Debug.Log(managerCount);
    //     }
    // }

    //Update total provides visual feedback about how many employees you currently have employeed
    public void UpdateTotal()
    {
        for (int i = 0; i < managerCount && managerCount < 8; i++)
        {
            GameObject newEmployee = Instantiate(managerPrefab, managerTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();

            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f); 
            }
        }

        for (int i = 0; i < salesBroCount && salesBroCount < 8; i++)
        {
            GameObject newEmployee = Instantiate(salesBroPrefab, salesBroTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();
        
            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f);
            }
        }

        for (int i = 0; i < internCount && internCount < 8; i++)
        {
            GameObject newEmployee = Instantiate(internPrefab, internTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();

            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f);
            }
        }

        for (int i = 0; i < recruiterCount && recruiterCount < 8; i++)
        {
            GameObject newEmployee = Instantiate(recruiterPrefab, recruiterTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();

            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f);
            }
        }
        
        //simply controlling max and minimums of employees
        if (managerCount == maxEmployees)
        {
            managerCount = maxEmployees;
        }
        if (internCount == maxEmployees)
        {
            internCount = maxEmployees;
        }
        if (salesBroCount == maxEmployees)
        {
            salesBroCount = maxEmployees;
        }
        if (recruiterCount == maxEmployees)
        {
            recruiterCount = maxEmployees;
        }
        if (recruiterCount < 0)
        {
            recruiterCount = 0;
        }
        if (internCount < 0)
        {
            internCount = 0;
        }
        if (salesBroCount < 0)
        {
            salesBroCount = 0;
        }
        if (managerCount < 0)
        {
            managerCount = 0;
        }

        playerMoraleText.text = "Morale: " + playerMorale + "/" + maxHealth;

        if (playerMorale >= maxHealth)
        {
            playerMorale = maxHealth;
        }

    }
    
    public void AddManagers()
    {
        managerCount++;
        internCount++;
        recruiterCount++;
        salesBroCount++;
        UpdateTotal();
    }

    public void SuckMorale()
    {
        UpdateTotal();
        managerCount--;
        internCount--;
        recruiterCount--;
        salesBroCount--;
        if (playerMorale < maxHealth)
        {
            playerMorale++;
        }
    }

    public void Attack()
    {
        mainMenu.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //setting main canvas
        mainMenu.SetActive(true);
        UpdateTotal();
    }
}
