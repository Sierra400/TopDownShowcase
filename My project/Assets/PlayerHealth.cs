using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float health = 10;
    [SerializeField]
    string levelToLoad;
    float maxhealth;
    [SerializeField]
    Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;
        healthBar.fillAmount = health / maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // we want to take damage IF the player hits the enemy capsule 
        //bool key = true; 
        if (collision.gameObject.tag == "Enemy")
        {
            //health = health - 1;
            health -= 1;
            healthBar.fillAmount = health / maxhealth;
            //health--;
            //consequences for taking damage
            //IF we take damage so health is below 0, reload level 
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            healthBar.fillAmount = health / maxhealth;
            if (health <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene(levelToLoad);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        health -= 1;
        healthBar.fillAmount = health / maxhealth;
        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
