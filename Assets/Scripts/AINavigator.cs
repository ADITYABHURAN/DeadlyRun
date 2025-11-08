using UnityEngine;

public class AINavigator : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
}