using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CameraController camControl;
    drop_projectile dropProjectile;
    BossHealth boss;
    private Camera cam;
    [SerializeField] public Transform playerPosition;
    [SerializeField] public Transform respawnPoint;
    public static Transform respawnLocation;
    public static Transform playerLocation;

    void Start()
    {
        camControl = GameObject.Find("Camera").GetComponent<CameraController>();
        dropProjectile = GameObject.Find("ProjectileSpawner").GetComponent<drop_projectile>();

        playerLocation = playerPosition;
        respawnLocation = respawnPoint;
        cam = Camera.main;
        if (GameObject.Find("DestroyProjectile")) { 
            boss = GameObject.Find("DestroyProjectile").GetComponent<BossHealth>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //kill player if hit by projectile
        if (collision.tag == "Projectile" && gameObject && boss.killed == false)
        {
            RespawnMenu.Pause();

            camControl.enabled = true;
            dropProjectile.enabled = false;

            gameObject.GetComponent<PlayerMovement> ().enabled = true;
            cam.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 6f, 2f);
        }
    }

}
