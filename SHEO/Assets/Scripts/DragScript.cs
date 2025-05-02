using System.Collections;
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
    private MinionManager mManager;
    public GameObject gObject;
    public GameManagerReal gameManager;


    void Start()
    {
        areaManager = GameObject.Find("AreaManager").GetComponent<AreaManagerScript>();
        movement = GetComponent<MinionMovementScript>();
        mManager = gameObject.GetComponent<MinionManager>();
        gObject = GameObject.Find("GayManager");
        gameManager = gObject.GetComponent<GameManagerReal>();

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
            mManager.minionState = MinionManager.MinionState.Owned;
        }
        
        else if (intersectingBlank && mManager.minionState == MinionManager.MinionState.Owned)
        {
            transform.position = touchedBlank.transform.position;
            movement.speed = 0f;
            Debug.Log("dropped onto" + touchedBlank.name);

            switch (touchedBlank.name)
            {
                case "BlankZyn":
                    gameManager.ZynVortexNew();
                    Debug.Log("fired zynvortexnew");
                    //FOR SOME REASON this gets doubled, lol
                    //destroy the prefab
                    Destroy(gameObject, 1f);
                    
                    break;
                case "BlankRecruit":
                    gameManager.AddMinions();
                    //destroy self
                    Destroy(gameObject, 1f);
                    break;
                case "BlankHeal":
                    gameManager.Heal();
                    //destroy self
                    Destroy(gameObject, 1f);
                    break;
                default:
                    break;
            }
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
            //Debug.Log(touchedBlank.name);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Blank"))
        {
            intersectingBlank = false;
        }
    }
    
    // IEnumerator DestroyMinionPrefab()
    // {
    //     yield return new WaitForSeconds(1f); // wait 1 second
    //     Destroy(gameObject);
    // }
  
}
