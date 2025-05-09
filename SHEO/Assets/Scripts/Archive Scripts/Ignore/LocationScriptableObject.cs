using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu
    (fileName = "LocationScriptableObject", 
    menuName = "Scriptable Objects/LocationScriptableObject")]

//when in [], make a modification to the editor
public class LocationScriptableObject : ScriptableObject
{
    public string locationName = "New Location";
    public string locationDesc = "Description";
    public Sprite image;

    public LocationScriptableObject north;
    public LocationScriptableObject south;
    public LocationScriptableObject east;
    public LocationScriptableObject west;
    public void UpdateUI(GameManager gm)
    {
        if (image != null)
        {
            gm.image.sprite = image;
            gm.image.gameObject.SetActive(true);

        }
        else
        {
            gm.image.gameObject.SetActive(false);
        }
        gm.title.text = locationName;
        gm.description.text = locationDesc;


        if (north == null)
        {
            gm.northButt.gameObject.SetActive(false);
        }
        else
        {
            north.south = this;
            gm.northButt.gameObject.SetActive(true);
        }
        
        if (south == null)
        {
            gm.southButt.gameObject.SetActive(false);
        }
        else
        {
            south.north = this;
            gm.southButt.gameObject.SetActive(true);

        }
        
        if (east == null)
        {
            gm.eastButt.gameObject.SetActive(false);
        }
        else
        {
            east.west = this;
            gm.eastButt.gameObject.SetActive(true);

        }
        
        if (west == null)
        {
            gm.westButt.gameObject.SetActive(false);
        }
        else
        {
            west.east = this;
            gm.westButt.gameObject.SetActive(true);

        }
        
        // north.south = this;
        // east.west = this;
        // west.east = this;
        //this way you dont hvae to wire all the stuff in your scriptable objects and it then persists
    }
    
    
}
