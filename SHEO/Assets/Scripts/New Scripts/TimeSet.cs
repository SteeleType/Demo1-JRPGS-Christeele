using System.Collections;
using System.Linq;
using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class TimeSet : MonoBehaviour
{
    public float timer; 
    public TextMeshPro timerText;
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        timer--;
        timerText.text = Mathf.Round(timer / 100).ToString();
        if (timer <= 90)
        {
            Destroy(gameObject);
        }
    }
}
