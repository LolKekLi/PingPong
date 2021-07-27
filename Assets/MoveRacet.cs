using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRacet : MonoBehaviour
{
    public float speed = 30;
    public string axis;
    public Sprite[] sprites;

    private int indexLeft = 1;
    private int indexRight = 1;

    private int helthLeft = 4;
    private int helthRight = 4;
    
    private GameObject left;
   
    private GameObject right;

    public Canvas LooseScene;

    

    void Start()
    {

        left = GameObject.Find("Игрок");
        right = GameObject.Find("Враг");
        left.SetActive(true);
        right.SetActive(true);

        Ball.damage += Ball_Damage;
        Ball.health += Ball_Health;
        Ball.increase += Ball_Incrase;
    }


    private void Ball_Incrase(GameObject obj)
    {
        if (obj.name == "Игрок")
        {
          
            obj.gameObject.transform.localScale +=  new Vector3(0, 0.01f, 0);
           
        }
        else
        {
            obj.gameObject.transform.localScale += new Vector3(0, 0.01f, 0);
        }

        
    }

    private void Ball_Health(GameObject obj)
    {
        if (obj.name == "Игрок")
        {
           
            if (indexLeft > 0 ) indexLeft--;
            if (helthLeft < 5)  helthLeft++;
            obj.GetComponent<SpriteRenderer>().sprite = sprites[indexLeft];
        }
        else
        { 
            if (indexRight > 0) indexRight--;
            if (helthRight < 5)  helthRight++;
            obj.GetComponent<SpriteRenderer>().sprite = sprites[indexRight];
        }
        
    }

    private void Ball_Damage(GameObject obj)
    {
        if (obj.name == "Игрок")
        {
            helthLeft--;
            indexLeft++;
            if (helthLeft <= 0)
            { 
                left.SetActive(false);
                indexLeft = 1;
                indexRight = 1;

                helthLeft = 4;
                helthRight = 4;

                LooseScene.gameObject.SetActive(true);
               
            }
            else
            {
                obj.GetComponent<SpriteRenderer>().sprite = sprites[indexLeft];
              
            }
           
        }
        else
        {
           
  
            helthRight--;
            indexRight++;
            if (helthRight <= 0)
            {
               
                right.SetActive(false);
                indexLeft = 1;
                indexRight = 1;

                helthLeft = 4;
                helthRight = 4;
                LooseScene.gameObject.SetActive(true);

            }
            else
            {
                obj.GetComponent<SpriteRenderer>().sprite = sprites[indexRight];
               
            }
            
        }
        
    }

    void Update()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}