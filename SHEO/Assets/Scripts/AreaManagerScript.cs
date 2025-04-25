using UnityEngine;

public class AreaManagerScript : MonoBehaviour
{
    //rectangle stuff
    public Rect ownedRect = new Rect(-150f, -115f, 160f, 95f);
    public Color fillColor = new Color(0f, 1f, 0f, 0.3f); // green with alpha


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Rectangle code

    void OnDrawGizmos()
    {
        Gizmos.color = fillColor;

        // Draw the filled box (as a thin cube)
        Vector3 center = new Vector3(ownedRect.x + ownedRect.width / 2f, ownedRect.y + ownedRect.height / 2f, 0);
        Vector3 size = new Vector3(ownedRect.width, ownedRect.height, 0.01f);
        Gizmos.DrawCube(center, size);

        // Optional: draw the outline
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, size);
    }

}
