using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSquare : MonoBehaviour
{
    SpriteRenderer spriteRender;

    [SerializeField] [Range(0, 5)] int weight = 1;      // weight == number on square
    [SerializeField] float DestroyDelay = 0.4f;
    public PlayerController Player;                     // access for isMoving and firstMove
    public bool isLocked;
    public GameObject Nr1Sprite, Nr2Sprite, Nr3Sprite, Nr4Sprite, Nr5Sprite, ActiveChild;
   [SerializeField] ParticleSystem hitEffect;

    //private bool WeightDecreased = false;
    
    private void Start()
    {
        Player.WinStatus += weight;                      // every block spawned in one level adds up to a total sum
        spriteRender = GetComponent<SpriteRenderer>();
        
        InitializeChildrenSprites();                        // initialize level
        ToggleNumbers();                                    // needs to be called before 
        
        ActiveChild = GetComponent<GameObject>();
        GetActiveChild();
    }
    private void Update()
    {

        if (!isLocked)          // if coin exists locks the chosen square 
        {
            ToggleNumbers();    // switches numbers and colors while interacting with player
        }
        else
        {
            
            ToggleLocked();     // turns number gray and border yellow if locked
        }
 
         if ( Player.hitNumber && !Player.isMoving)
         {
            
            DecreaseSquareWeight();         // decrease value on square and value of total sum by 1
         }

        if (weight == 0)
        {
            DestroySquare();                 
        }


    }
    private void DecreaseSquareWeight()
    {
        if(gameObject.name == Player.thisSquare)
        {
            Player.hitNumber = false;
           // ActiveChild.SetActive(false);
            weight -= 1;
            Player.WinStatus -= 1;
            hitEffect.Play();

        }
    }

    private void DestroySquare()
    {
        spriteRender.enabled = false;                   //first we disable the render so the hitbox will linger for a while 
        Nr1Sprite.SetActive(false);                     //player can still move for one second off the block if he is fast enough
        Destroy(gameObject, DestroyDelay);  
    }
    void ToggleNumbers()
    {
        gameObject.tag = "NumberSquare";
        switch (weight)
        {
            case 1:
                Nr1Sprite.SetActive(true);
                Nr2Sprite.SetActive(false);
                spriteRender.color = new Color(1f, 0.767f, 0.705f, 1);//255 194 180
                Nr1Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 0.767f, 0.705f, 1);
                break;                                                                                          
            case 2:
                Nr2Sprite.SetActive(true);
                Nr3Sprite.SetActive(false);
                spriteRender.color = new Color(0.980f, 0.862f, 0.819f, 1);//250 220 209
                Nr2Sprite.GetComponent<SpriteRenderer>().color = new Color(0.980f, 0.862f, 0.819f, 1);
                break;
            case 3:
                Nr3Sprite.SetActive(true);
                Nr4Sprite.SetActive(false);
                spriteRender.color = new Color(0.819f, 0.780f, 0.729f, 1);//209 199 186
                Nr3Sprite.GetComponent<SpriteRenderer>().color = new Color(0.819f, 0.780f, 0.729f, 1);
                break;
            case 4:
                Nr4Sprite.SetActive(true);
                Nr5Sprite.SetActive(false);
                spriteRender.color = new Color(1f, 0.862f, 0.713f, 1);//255 220 182
                Nr4Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 0.862f, 0.713f, 1);
                break;

            case 5:
                Debug.Log("Hi");
                Nr5Sprite.SetActive(true);
                spriteRender.color = new Color(0.952f, 0.929f, 0.788f, 1);//243 237 201
                Nr5Sprite.GetComponent<SpriteRenderer>().color = new Color(0.952f, 0.929f, 0.788f, 1);
                break;
            case 0:
                break;
        }
    }
    void ToggleLocked()
    {
        gameObject.tag = "Locked";
        spriteRender.color = new Color(0.925f, 0.858f, 0.294f, 1);//149 143 137
        ActiveChild.GetComponent<SpriteRenderer>().color = new Color(0.482f, 0.482f, 0.482f);//123 123 123
    }

    private void InitializeChildrenSprites()
    {
        Nr1Sprite = transform.GetChild(0).gameObject;
        Nr2Sprite = transform.GetChild(1).gameObject;
        Nr3Sprite = transform.GetChild(2).gameObject;
        Nr4Sprite = transform.GetChild(3).gameObject;
        Nr5Sprite = transform.GetChild(4).gameObject;
    }
    private void GetActiveChild()
    {

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true && gameObject.transform.GetChild(i).gameObject.name != "SquareParticles")
            {
                ActiveChild = transform.GetChild(i).gameObject;
            }
        }
    }  // for when toggling numbers we dont get leftovers behind
}