using UnityEngine;

public class DragScript : MonoBehaviour
{

    private MinionMovementScript movement;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector2 newPosition;
    private Vector3 initialPosition;
    private MinionManager.MinionState minionState;
    public AreaManagerScript areaManager;
    private bool intersectingBlank = false;
    private GameObject touchedBlank;


    void Start()
    {
        areaManager = GameObject.Find("AreaManager").GetComponent<AreaManagerScript>();
        movement = GetComponent<MinionMovementScript>();
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
            MinionManager mManager = gameObject.GetComponent<MinionManager>();
            mManager.minionState = MinionManager.MinionState.Owned;
        }
        
        else if (intersectingBlank)
        {
            transform.position = touchedBlank.transform.position;
            movement.speed = 0f;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blank"))
        {
            intersectingBlank = true;
            GameObject touchedObject = other.gameObject;
            touchedBlank = touchedObject;
            Debug.Log(touchedBlank.name);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Blank"))
        {
            intersectingBlank = false;
        }
    }
  
}
