using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    public float frameRate;

    public SpriteRenderer spriteRenderer;

    public List<Sprite> NSprites;
    public List<Sprite> NeSprites;
    public List<Sprite> ESprites;
    public List<Sprite> SeSprites;
    public List<Sprite> SSprites;

    float idleTime;

    Vector2 direction;
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;//get direction normalized, so diag movement isn't faster
        
        rb.velocity = direction * moveSpeed;//set veloctiy based on direction and speed

        HandleSpriteFlip();//handle flip if east or west

        List<Sprite> directionSprites = GetSpriteDirection();//get sprites based on direction

        if(directionSprites != null) {//if there is input

            float playTime = Time.time - idleTime;//time since walk start
            int totalFrames = (int)(playTime * frameRate);//total frames since walk start
            int frame = totalFrames % directionSprites.Count;//current frame

            spriteRenderer.sprite = directionSprites[frame];

        } else {//no input, idle animation here?

            idleTime = Time.time;
        }
       
    }

  
    void HandleSpriteFlip() {

         if(!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(spriteRenderer.flipX && direction.x > 0)//facing left and move right, flip
        {
            spriteRenderer.flipX = false;
        }
    }
    
    List<Sprite> GetSpriteDirection() {

        List<Sprite> selectedSprites = null;

        if(direction.y > 0){//north/ positive y   

            if(Mathf.Abs(direction.x) > 0) {//east or west
                selectedSprites = NeSprites;

            } else {//north neutral x
                selectedSprites = NSprites;
            }

        } else if(direction.y < 0){//south/negative y   

            if(Mathf.Abs(direction.x) > 0) {//east or west
                selectedSprites = SeSprites;

            } else {//south neutral x
                selectedSprites = SSprites;
            }

        } else {//neutral y
            
                if(Mathf.Abs(direction.x) > 0) {//east or west
                    selectedSprites = ESprites;
                }

        }

        return selectedSprites;
    }

   
}
