using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    private bool ShouldDieFromCollision(Collision2D collision2D)
    {
        Bird bird = collision2D.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            return true;
        }

        if(collision2D.contacts[0].normal.y < -0.5)
        {
            return true; 
        }

        return false;
    }

    void Die()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        //gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        if(ShouldDieFromCollision(collision))
        {
            Die();
        }
    }
}
