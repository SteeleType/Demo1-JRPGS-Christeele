using TMPro;
using UnityEngine;

public class EmployeeHealth : MonoBehaviour
{  
    public int employeeBurnOut;
    public TextMeshProUGUI employeeBurnOutText;

    public int EmployeeBurnOut
    {
        set
        {
            employeeBurnOut = value; 
            LowerEmployeeBurnOut();
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
