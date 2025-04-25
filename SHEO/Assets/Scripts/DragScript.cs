using UnityEngine;

public class DragScript : MonoBehaviour
{

    public MinionMovementScript movement;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector2 newPosition;
    private Vector3 initialPosition;
    private MinionManager.MinionState minionState;
    public AreaManagerScript areaManager;


    void Start()
    {
        areaManager = GameObject.Find("AreaManager").GetComponent<AreaManagerScript>();
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        initialPosition = transform.position;
    
        Debug.Log("clicked intern");
    }

    private void OnMouseUp()
    {
        isDragging = false;
        newPosition = new Vector2(transform.position.x, transform.position.y);
        
        if (areaManager.ownedRect.Contains(newPosition))
        {
            Debug.Log("inside the owned rectangle!");
            //once minion has been dragged into your rectangle, sets their state to OWNED
            minionState = MinionManager.MinionState.Owned;
        }
        else
        {
            Debug.Log("outside the owned rectangle!");
            transform.position = initialPosition;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    
  
}
