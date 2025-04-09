using UnityEngine;

public class MinionManager : MonoBehaviour
{
    public enum MinionType  {
        Intern, Manager, SalesBro, Recruiter
    };

    public MinionType minionType;

    public enum MinionState
    {
        Owned, Available, Sniped
    }
    
    public MinionState minionState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
