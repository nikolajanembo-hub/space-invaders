using Unity.VisualScripting;
using UnityEngine;

public class InvadersGroupScript : MonoBehaviour
{
    public InvadersScript[] prefabs;
    public int rows = 5;
    public int collumns = 11;
    public float speed = 5;
    public float speedIncrement = 0.5f;
    private Vector3 _direction = Vector2.right;
    [SerializeField] private ScreenBorderData ScreenBorderData;
    public bool allInvadersDestroyed = true;
    public ScoreData scoreData;
    Vector3 Startingpostion;
    private void Awake()
    {
        Startingpostion = transform.position;
        for (int row = 0; row < this.rows; row++)
        {
            float width = 0.12f * (this.collumns - 1);
            float height = 0.12f * (this.rows - 1);

            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPositioning = new Vector3(centering.x, centering.y + (row * 0.12f), 0.0f);

            for (int col = 0; col < this.collumns; col ++)
            {
                InvadersScript invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPositioning;
                position.x += col * 0.12f;
                invader.transform.localPosition = position;
            }
        }
    }
    private void Update()
    {
        if (GameManager.instance.gameState != GameState.Running)
        {
            return;
        }
        this.transform.position += _direction * speed * Time.deltaTime;

        bool allDestroyed = true; 

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= ScreenBorderData.Rightedge)
            {
                AdvanceRow();
            }
            else if(_direction == Vector3.left && invader.position.x <= ScreenBorderData.Leftedge)
            {
                AdvanceRow();
            }

            if (invader.gameObject.activeSelf)
            {
                allDestroyed = false;
            }
        }

        allInvadersDestroyed = allDestroyed;

        if (allInvadersDestroyed == true)
        {
            speed += speedIncrement;
            transform.position = Startingpostion;
            for (int row = 0; row < this.rows; row++)
            {
                float width = 0.12f * (this.collumns - 1);
                float height = 0.12f * (this.rows - 1);

                Vector2 centering = new Vector2(-width / 2, -height / 2);
                Vector3 rowPositioning = new Vector3(centering.x, centering.y + (row * 0.12f), 0.0f);

                for (int col = 0; col < this.collumns; col++)
                {
                    InvadersScript newInvader = Instantiate(this.prefabs[row], this.transform); 
                    Vector3 position = rowPositioning;
                    position.x += col * 0.12f;
                    newInvader.transform.localPosition = position;
                }
            }
        }
       
    }
     
    private void AdvanceRow()
    {
        _direction.x *= -1f;
        Vector3 position = this.transform.position;
        position.y -= 0.1f;
        this.transform.position = position;
    }
}
