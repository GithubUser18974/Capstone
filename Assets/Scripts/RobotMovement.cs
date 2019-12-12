using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotMovement : MonoBehaviour
{
    Transform player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == true)
        {
            agent.SetDestination(player.position);
            transform.LookAt(new Vector3(player.position.x, player.position.y, player.position.z));
        }
   
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.Instance.PlayerGetHit();
        }
    }
}

