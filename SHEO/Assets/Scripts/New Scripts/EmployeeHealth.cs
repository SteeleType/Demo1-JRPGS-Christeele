using TMPro;
using UnityEngine;

public class EmployeeHealth : MonoBehaviour
{  
    public int employeeBurnOut;
    public TextMeshPro employeeBurnOutText;

    void Start()
    {
        employeeBurnOutText.text = employeeBurnOut.ToString();
    }
    public int EmployeeBurnOut
    {
        set
        {
            employeeBurnOut = value; 
            if (employeeBurnOut <= 0)
            {
                Destroy(this.gameObject);
                Destroy(employeeBurnOutText);
            }
        }
        get
        {
            return employeeBurnOut; 
        }
    } 
    
    
    public void LowerEmployeeBurnOut()
    {
        EmployeeBurnOut -= 1;
        employeeBurnOutText.text = employeeBurnOut.ToString();
    }
    
}
