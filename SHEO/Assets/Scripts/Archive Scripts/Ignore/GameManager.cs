using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Button northButt;
    public Button southButt;
    public Button eastButt;
    public Button westButt;
    public Image image;
    public LocationScriptableObject currentLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UpdateLocation();
        //instead of doing the function here, can call the function that's within the scriptable object
        currentLocation.UpdateUI(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void UpdateLocation()
    // {
    //     title.text = currentLocation.locationName;
    //     description.text = currentLocation.locationDesc;
    // }


    public void MoveDirection(int dir)
    {
        // if (dir == 0) // 0  is North
        // {
        //     currentLocation = currentLocation.north;
        //     currentLocation.UpdateUI(this);
        // }
        
        switch (dir)
        {
            case 0:
                //currentLocation.north.south = currentLocation; 
                // set the location south of the location north of us to the current location
                //the change we made in code persists in scriptable object
                currentLocation = currentLocation.north;
                break;
            case 1:
                currentLocation = currentLocation.east;
                break;
            case 2:
                currentLocation = currentLocation.south;
                break;
            case 3:
                currentLocation = currentLocation.west;
                break;
            default:
                Debug.Log("Invalid Direction: " + dir);
                break;
        }
        currentLocation.UpdateUI(this);
        
    }
}
