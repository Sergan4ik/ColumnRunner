using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CannonBall : MonoBehaviour
{
    public float speed = 10;
    public Vector3 direction = Vector3.forward;
    public GameObject explosionPrefab;
    public float explosionForce, explosionRadius , damageRadius;
    public int damage = 1;
    [HideInInspector] public Rigidbody rb;
    private CinemachineImpulseSource impulseSource;
    private bool canExplode = true;
    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canExplode)
        {
            Explode();
            canExplode = false;
        }
    }

    public void Explode()
    {
        GameObject currentExplode = Instantiate(explosionPrefab, this.gameObject.transform.position , Quaternion.identity) as GameObject;
        ParticleSystem psExplode = currentExplode.GetComponent<ParticleSystem>();
        float duration = psExplode.main.duration;
        impulseSource.GenerateImpulse();

        #region ApplyDamageToPlayer
        LayerMask playerLayer = LayerMask.GetMask("Player");
        bool willDamage = Physics.CheckSphere(this.transform.position , damageRadius , playerLayer);
        if (willDamage)
            Player.instance.playerStats.TakeDamage(damage);
        #endregion

        #region AddExplosionForce
        
        LayerMask ragdollLayer = LayerMask.GetMask("Ragdoll");
        Collider[] cols = Physics.OverlapSphere(this.transform.position, explosionRadius , ragdollLayer);
        foreach(Collider col in cols)
        {
            if (col.attachedRigidbody != null)
            {
                Rigidbody currentRB = col.attachedRigidbody;
                currentRB.AddExplosionForce(explosionForce, this.transform.position, explosionRadius);
            }
        }
        #endregion 

        Destroy(this.gameObject);
        Destroy(currentExplode, duration);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, damageRadius);
        Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
    }
}
