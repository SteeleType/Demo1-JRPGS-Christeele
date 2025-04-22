using System.Collections.Generic;
using UnityEngine;

public class GeneratingEmployees : MonoBehaviour
{
    public MinionManager minionManager;
    
    MinionManager.MinionType minionType;
    public GameObject internPrefab;
    public GameObject managerPrefab;
    public GameObject recruiterPrefab;
    public GameObject salesBroPrefab;
    public int spacesAvailable = 0;
    private GameObject instantiatedEmployees;
    public float spacing;
    public Transform employeeGeneratorTransform;
    public List<string> spawnedEmployees = new List<string>();
    public List<GameObject> employees = new List<GameObject>();
    public Transform randomLocation;



    public void CreateMinions()
    {
        //create random minion
        minionType = (MinionManager.MinionType)Random.Range(0, 4);
        randomLocation = new GameObject().transform;

        switch (minionType)
        {
            case MinionManager.MinionType.Intern:
                Debug.Log("Creating intern");
                Instantiate(internPrefab, employeeGeneratorTransform);
                break;
            case MinionManager.MinionType.Manager:
                Debug.Log("Creating manager");
                break;
            case MinionManager.MinionType.Recruiter:
                Debug.Log("Creating recruiter");
                break;
            case MinionManager.MinionType.SalesBro:
                Debug.Log("Creating sales bro");
                break; 
            default:
                break;
        }
        
        Debug.Log(minionType);
    }
    
    public void RecruitGenerator()
    {
        //this destroys the prefabs so it can run a new one 
        foreach (Transform child in employeeGeneratorTransform)
        {
            Destroy(child.gameObject);
        }
        minionType = (MinionManager.MinionType)Random.Range(0, 4);
        spawnedEmployees.Add(minionType.ToString());
        
        //this forloop is to represent what current recruitable employees are on the list
        for (int i = 0; i < spawnedEmployees.Count; i++)
        {
            if (spawnedEmployees[i] == "Intern")
            {
                GameObject instantiatedEmployees = Instantiate(internPrefab, employeeGeneratorTransform);
                RectTransform rt = instantiatedEmployees.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.anchoredPosition = new Vector2(i * spacing, 0f);
                }
            }
            
            if (spawnedEmployees[i] == "Manager")
            {
                instantiatedEmployees = Instantiate(managerPrefab, employeeGeneratorTransform);
                RectTransform rt = instantiatedEmployees.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.anchoredPosition = new Vector2(i * spacing, 0f);
                }
            }

            if (spawnedEmployees[i] == "Recruiter")
            {
                instantiatedEmployees = Instantiate(recruiterPrefab, employeeGeneratorTransform);
                RectTransform rt = instantiatedEmployees.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.anchoredPosition = new Vector2(i * spacing, 0f);
                }
            }

            if (spawnedEmployees[i] == "SalesBro")
            {
                instantiatedEmployees = Instantiate(salesBroPrefab, employeeGeneratorTransform);
                RectTransform rt = instantiatedEmployees.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.anchoredPosition = new Vector2(i * spacing, 0f);
                }
            }
        }
    }
    void Start()
    {
        //RecruitGenerator();
        CreateMinions();
    }
}
