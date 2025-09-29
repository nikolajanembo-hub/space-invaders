using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
 
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, 0);
        }
    }
}
