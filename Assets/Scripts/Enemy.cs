using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float attackDistance = 2f;

    private float attackDamage = 1f;

    private Vector2 targetPosition;

    private Vector2 direction;
    
#pragma warning disable 108,114
    // ReSharper disable once IdentifierTypo
    private Rigidbody2D rigidbody;
#pragma warning restore 108,114

    private Player targetPlayer;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    
    private IEnumerator ChangeTargetPositionCoroutine()
    {
        while(true)
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * 10f;
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
    
    
    private void Update ()
    {
       
        Attack();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (targetPlayer != null) targetPosition = targetPlayer.transform.position;

        else return;

        direction = targetPosition - rigidbody.position;
        var targetVelocity = direction.normalized;
        
        rigidbody.MovePosition(targetPosition * (speed * Time.fixedDeltaTime));

        
        rigidbody.MovePosition(rigidbody.position + direction * (speed * Time.fixedDeltaTime));
       
        // rigidbody.velocity = Vector3.Lerp(
        //     rigidbody.velocity,
        //     targetVelocity,
        //     Time.deltaTime / 2f);

        // transform.right = (Vector2)direction;
    }

    

    private void Attack()
    {
        if (targetPlayer == null)
            return;

        var distance = (targetPlayer.transform.position - transform.position).magnitude;

        if (distance > attackDistance)
            return;

        Debug.Log("attack " + Time.deltaTime);
        
        
        // targetPlayer.GetComponent<Entity>().Health -= AttackDamage * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
            targetPlayer = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
            targetPlayer = null;
    }
    
}
