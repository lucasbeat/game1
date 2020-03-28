﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {

  public float jumpForce = 550;

  [SerializeField]
  private float walkSpeed;
  private Rigidbody2D rb;
  private Vector2 newMovement;
  private bool facingRight = true;

  private bool jump;

  private void Awake () {
    rb = GetComponent<Rigidbody2D> ();
  }

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  private void FixedUpdate () {
    rb.velocity = newMovement;

    if (jump) {
      jump = false;
      rb.velocity = Vector2.zero;
      rb.AddForce (Vector2.up * jumpForce);
    }
  }

  public void Jump () {
    jump = true;
  }

  public void Move (float direction) {
    float currentSpeed = walkSpeed;
    newMovement = new Vector2 (direction * currentSpeed, rb.velocity.y);

    if (facingRight && direction > 0) {
      Flip ();
    } else if (!facingRight && direction < 0) {
      Flip ();
    }
  }

  void Flip () {
    facingRight = !facingRight;

    transform.Rotate (0, 180, 0);
  }
}