//este script solo hace que siga al jugador y no tiene zonas de ataque ni nada de eso

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField]
    GameObject target;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();    
    }

    void Update()
    {
        // Configura la posición del objetivo como destino del agente
        agent.SetDestination(target.transform.position);
    }
}
