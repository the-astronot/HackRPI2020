using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float MoveX,MoveY;
    public float IsoX, IsoY;
    public float speed, max_speed;
    private int prev_direction, direction;
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer car_sprite;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        rb = GetComponent<Rigidbody2D>();
        car_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxis("Horizontal") * speed;
        MoveY = Input.GetAxis("Vertical") * speed;

        IsoX = (MoveX) + (MoveY);
        IsoY = -1*(MoveX/2f) + (MoveY/2);

        rb.velocity = new Vector2(IsoX,IsoY);

        direction = GetDirection(IsoX, IsoY);
        if (direction!=0) {
            if (direction != prev_direction) {
                SwitchSprite(prev_direction, direction);
            }
        }
        
    }

    int GetDirection(float IsoX, float IsoY) {
        // 0 == Not Moving
        // 1 == TopRight
        // 2 == TopLeft
        // 3 == BottomLeft
        // 4 == BottomRight
        if (IsoX > 0){
            if (IsoY > 0) {
                return 1;
            } else {
                return 4;
            }
        } else if (IsoX <0) {
            if (IsoY > 0) {
                return 2;
            } else {
                return 3;
            }
        } else {
            return 0;
        }
    }

    void SwitchSprite(int prev_direction, int direction) {
        car_sprite.sprite = sprites[direction-1];
    }
}
