using UnityEngine;

[CreateAssetMenu(fileName = "ScreenBorderData", menuName = "Scriptable Objects/ScreenBorderData")]
public class ScreenBorderData : ScriptableObject
{
    private float leftEdge;
    private float rightEdge;
    private float bottomEdge;
    private float topEdge;
   [SerializeField] private float offSet =0.05f;
    public float Leftedge { get => leftEdge + offSet; set => leftEdge = value; }
    public float Rightedge { get => rightEdge - offSet; set => rightEdge = value; }
}
