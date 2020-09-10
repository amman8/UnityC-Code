using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnimyControler : MonoBehaviour
{

    public float lookradius = 10f;

    Transform target;
    NavMeshAgent agent;
    public static int check = 1;

    public Animator Enemy;
    public bool getup = false;//Enemy Run Animation will Start
    public bool getdown = false;//Enemy stop Running Animation
    public AudioSource aud;

    void Start()
    {       
            Enemy = GetComponent<Animator>();
            target = PlayerManager.instance.player.transform;
            agent = GetComponent<NavMeshAgent>();    
    }

    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(EnemyDamage.Enemycheck==false)
        {
            if (distance <= lookradius)
            {
                //getup = true;
                agent.SetDestination(target.position);
                Enemy.SetBool("a", true);
                getdown = false;
                aud.enabled = true;
                lookradius = 25f;
            }

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //getdown = true;
            Enemy.SetBool("a", false);          
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }
}
