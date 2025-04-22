using UnityEngine;

public class MinionMovementScript : MonoBehaviour
{

    public float speed = 10f;

    public float directionChangeInterval = 2f;
    private float lastDirectionChangeAt;

    private Vector2 direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastDirectionChangeAt = Time.time;

        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        if (directionChangeInterval >= Time.time - lastDirectionChangeAt) {
            transform.Translate(direction * speed * Time.deltaTime);
        } else {
            // Change direction
            lastDirectionChangeAt = Time.time;
            direction = Random.insideUnitCircle.normalized;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Random.insideUnitCircle.normalized;


    }
}
