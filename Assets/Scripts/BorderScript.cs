using Unity.VisualScripting;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var player = collision.GetComponent<PlayerController>();
            if (this.gameObject.name == "BorderRight")
            {
                player.canMoveRight = false;
            }
            else
            {
                player.canMoveLeft = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        if (this.gameObject.name == "BorderRight")
        {
            player.canMoveRight = true;
        }
        else
        {
            player.canMoveLeft = true;
            Debug.Log(player);
        }
    }
}
