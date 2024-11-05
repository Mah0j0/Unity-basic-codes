using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    GameObject target;
    [SerializeField]
    int persecutionArea;
    [SerializeField]
    int attackArea;
    bool persecution=true;
    bool attack = true;

    [SerializeField]
    LayerMask layerDetection;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        Persecution();
        if(persecution)
        {
            agent.SetDestination(target.transform.position);
            if(attack){
                //animacion de ataque
            }
        }
        else
        {
            //animacion de persecucion
        }

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z),persecutionArea);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), attackArea);
    }
    void Persecution()
    {
        bool rangePersecution = Physics.CheckCapsule(transform.position, transform.position, persecutionArea, layerDetection);
        if(rangePersecution)
        {
            persecution = true;
            agent.speed = 6.0f;
        }
        else
        {
            persecution = false;
            agent.speed = 3.5f;
        }
    }
}