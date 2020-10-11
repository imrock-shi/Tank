using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float moveSpeed = 10;
    public bool isPlayerBullet;

    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");

                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Wall":
                print(11);
                Destroy(collision.gameObject);  //碰到墙就销毁墙和自己
                Destroy(gameObject);
                break;
            case "Barrier":
                if(isPlayerBullet)
                    collision.SendMessage("PlayAduio");

                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
