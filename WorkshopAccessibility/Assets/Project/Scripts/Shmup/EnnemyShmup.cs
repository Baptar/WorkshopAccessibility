using System;
using UnityEngine;

public class EnnemyShmup : MonoBehaviour
{
    [SerializeField] private PlayerShmup player;
    private bool canDamage = true;
    public int life = 2; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.GetComponent<PlayerShmup>())
        {
            canDamage = false;
            player.takeDamage();
            AudioManager.instance.PlaySFX(AudioManager.instance.explosionVaisseau);
            AudioManager.instance.PlaySFX(AudioManager.instance.explosion);
            Destroy(gameObject);
        }
        else if (other.GetComponent<Missile>())
        {
            Debug.Log("Ennemy touched by Missile");
            life--;
            if (life <= 0)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.explosion);
                player.addScore(100);
                canDamage = false;
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
