using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {

  [SerializeField]
  private float walkSpeed;
  private Rigidbody2D rb;
  private Vector2 newMovement;
  private bool facingRight = true;

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