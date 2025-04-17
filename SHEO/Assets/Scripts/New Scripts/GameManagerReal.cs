using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]

public enum BattleStates
{
    PLAYERTURN, ENEMYTURN
}
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
    public int enemyDamage;
    public BattleStates state;
    public TextMeshProUGUI playerMoraleText;
    
    //enemy variables
    public int enemyMorale;
    public int maxEnemyMorale;
    public TextMeshProUGUI enemyMoraleText;

    //these are the different menus to work with in the UI
    public GameObject mainMenu;
    public GameObject attackMenu;
    public GameObject enemyTurnMenu;
    public TextMeshProUGUI enemyTurnText;

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

        //this destroys the instatiated objects so that the numbers can be accurate
        foreach (Transform child in managerTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in salesBroTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in internTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in recruiterTransform)
        {
            Destroy(child.gameObject);
        }
        
        //this instatiates the prefabs to represent the total of employees
        for (int i = 0; i < managerCount; i++)
        {
            GameObject newEmployee = Instantiate(managerPrefab, managerTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();

            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f); 
            }
        }

        for (int i = 0; i < salesBroCount; i++)
        {
            GameObject newEmployee = Instantiate(salesBroPrefab, salesBroTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();
        
            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f);
            }
        }

        for (int i = 0; i < internCount; i++)
        {
            GameObject newEmployee = Instantiate(internPrefab, internTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();

            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f);
            }
        }

        for (int i = 0; i < recruiterCount; i++)
        {
            GameObject newEmployee = Instantiate(recruiterPrefab, recruiterTransform);
            RectTransform rt = newEmployee.GetComponent<RectTransform>();

            if (rt != null)
            {
                rt.anchoredPosition = new Vector2(i * spacing, 0f);
            }
        }
        //update player health info
        playerMoraleText.text = "Morale: " + playerMorale + "/" + maxHealth;
        enemyMoraleText.text = "Morale: " + enemyMorale + "/" + maxEnemyMorale;
    }
    
    public void AddManagers()
    {
        
        managerCount++;
        internCount++;
        recruiterCount++;
        salesBroCount++;
        
    }

    public void SuckMorale()
    {
        
        managerCount--;
        internCount--;
        recruiterCount--;
        salesBroCount--;
        if (playerMorale < maxHealth)
        {
            playerMorale++;
        }
        UpdateTotal();
    }

    public void Attack()
    {
        mainMenu.SetActive(false);
        attackMenu.SetActive(true);
        
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        attackMenu.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //setting main canvas
        mainMenu.SetActive(true);
        attackMenu.SetActive(false);
        enemyTurnMenu.SetActive(false);

    }

    void Update()
    {
        //simply controlling max and minimums of employees
        if (managerCount >= maxEmployees)
        {
            managerCount = maxEmployees;
        }
        if (internCount >= maxEmployees)
        {
            internCount = maxEmployees;
        }
        if (salesBroCount >= maxEmployees)
        {
            salesBroCount = maxEmployees;
        }
        if (recruiterCount >= maxEmployees)
        {
            recruiterCount = maxEmployees;
        }
        if (recruiterCount <= 0)
        {
            recruiterCount = 0;
        }
        if (internCount <= 0)
        {
            internCount = 0;
        }
        if (salesBroCount <= 0)
        {
            salesBroCount = 0;
        }
        if (managerCount <= 0)
        {
            managerCount = 0;
        }
        if (playerMorale >= maxHealth)
        {
            playerMorale = maxHealth;
        }
        UpdateTotal();
    }
    
    
    //the rest of this is Attack Manager Scripts
    
    
    public void ZynVortext()
    {
        //cost of spell
        if (salesBroCount >= 2)
        {
            salesBroCount -= 2; 
            enemyMorale -= 2;
            StartCoroutine(EnemyTakesTurn());
        }
        else
        {
            return;
        }
    }

    public void CoffeeRun()
    {
        if (internCount >= 2)
        {
            internCount -= 2; 
            StartCoroutine(EnemyTakesTurn());
        }
        else
        {
            return;
        }
    }

    public void AnaylsisParalysis()
    {
        if (managerCount >= 3)
        {
            managerCount -= 3; 
            StartCoroutine(EnemyTakesTurn());
        }
        else
        {
            return;
        }
    }

    public void SynergyStorm()
    {
        if (managerCount >= 1 && internCount >= 1 && recruiterCount >= 1 && salesBroCount >= 1)
        {
            managerCount -= 1;
            internCount -= 1;
            recruiterCount -= 1;
            salesBroCount -= 1;
            StartCoroutine(EnemyTakesTurn());
        }
        else
        {
            return;
        }
    }

    public void SnipeEmployee()
    {
        if (recruiterCount >= 3)
        {
            recruiterCount -= 3;
            StartCoroutine(EnemyTakesTurn());
        }
        else
        {
            return;
        }
    }

    void EnemyTurn()
    {
        attackMenu.SetActive(false);
        mainMenu.SetActive(false);
        enemyTurnMenu.SetActive(true);
        enemyDamage = Random.Range(0, 3);
        if (enemyDamage == 0)
        {
            enemyTurnText.text = "The Enemy Missed You";
        }
        else
        {
            enemyTurnText.text = "The Enemy Hit You for " + enemyDamage;
        }
        playerMorale -= enemyDamage;
        state = BattleStates.PLAYERTURN;
    }

    void PlayerTurn()
    {
        mainMenu.SetActive(true);
        enemyTurnMenu.SetActive(false);
        state = BattleStates.ENEMYTURN;
    }
    IEnumerator EnemyTakesTurn()
    {
        EnemyTurn();
        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

}
