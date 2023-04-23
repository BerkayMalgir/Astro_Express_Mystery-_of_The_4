using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 public CharacterController2D controller;

 public float walkMove = 0f;
 public float walkSpeed = 20f;

 private void Update()
 {
  HorizontalMove();
 }

 private void HorizontalMove()
 {
  walkMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
  }

 private void FixedUpdate()
 {
  controller.Move(walkMove * Time.deltaTime);
 }
}
