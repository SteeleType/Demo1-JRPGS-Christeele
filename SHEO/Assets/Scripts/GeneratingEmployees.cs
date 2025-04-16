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
    private List<GameObject> spawnedEmployees = new List<GameObject>();
    public void RecruitGenerator()
    {
        Destroy(instantiatedEmployees);
        minionType = (MinionManager.MinionType)Random.Range(0, 4);
        if (minionType == MinionManager.MinionType.Intern)
        {
            instantiatedEmployees = Instantiate(internPrefab, transform);
            spacesAvailable++;
        }

        if (minionType == MinionManager.MinionType.Manager)
        {
            instantiatedEmployees = Instantiate(managerPrefab, transform);
            spacesAvailable++;
        }

        if (minionType == MinionManager.MinionType.Recruiter)
        {
            instantiatedEmployees = Instantiate(recruiterPrefab, transform);
            spacesAvailable++;
        }

        if (minionType == MinionManager.MinionType.SalesBro)
        {
            instantiatedEmployees = Instantiate(salesBroPrefab, transform);
            spacesAvailable++;
        }
    }

   
    void Start()
    {
        RecruitGenerator();
    }
}
