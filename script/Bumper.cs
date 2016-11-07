using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{

    public Vector3 direction;
    public Rigidbody ball;

    public void OnCollisionEnter(Collision collision)
    {
        direction = collision.contacts[0].point;
        ball.AddForce(direction * -140);

    }
}
