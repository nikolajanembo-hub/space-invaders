using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InvadersScript : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public ScoreData scoreData;
    [SerializeField]private int health = 2;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(animateSprites), this.animationTime, this.animationTime);
    }
    private void animateSprites()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
    public void Hit()
    {
        health--;
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        scoreData.Score++;
    }

}


