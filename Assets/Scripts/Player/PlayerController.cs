using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5f;

    public Transform gunTransform; 

    private Rigidbody2D body;
    private Master controls;
    private Vector2 moveInput;

    private Vector2 aimInput;


    private void Awake(){

        controls = new Master();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    private void FixedUpdate(){
        Move();
    }

    private void Move(){
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime; 
        body.MovePosition(body.position + movement);  }

    private void Update(){

        Shoot();

        if(UsingMouse()){
            AimWithMouse();
        }
        else{

        }
    }

    private void Shoot(){

        if (controls.Player.Shoot.triggered){
            
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
        }
    }

    private bool UsingMouse(){

        if (Mouse.current.delta.ReadValue().sqrMagnitude > 0.1){
            return true;
        }

        return false;

    }

    private void AimWithMouse(){
        
    }
}
