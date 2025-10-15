using UnityEngine;

public class ScreenBorderManager : MonoBehaviour
{
   [SerializeField] private ScreenBorderData ScreenBorderData;
    private void Start()
    {
        ScreenBorderData.Leftedge = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        ScreenBorderData.Rightedge = Camera.main.ViewportToWorldPoint(Vector3.right).x;
    }
}
