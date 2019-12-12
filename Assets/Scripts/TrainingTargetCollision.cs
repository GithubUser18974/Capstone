using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainingTargetCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            GameManager.Instance.IncrementScore();
            if (collision.gameObject.GetComponent<BoxCollider>() != null)
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (collision.gameObject.GetComponent<SphereCollider>() != null)
                collision.gameObject.GetComponent<SphereCollider>().enabled = false;

            if (this.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                collision.gameObject.transform.parent = transform;
                Animator s = GetComponent<Animator>();
                s.SetTrigger("Dead");
                GameManager.Instance.MakeRobotDead(transform.localPosition);
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<AudioSource>().clip = GameManager.Instance.RobotDie();
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().Play();
                GetComponent<SphereCollider>().enabled = false;

                Invoke("Dead", 5);
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            GameManager.Instance.IncrementScore();
            if(collision.gameObject.GetComponent<BoxCollider>()!=null)
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (collision.gameObject.GetComponent<SphereCollider>() != null)
                collision.gameObject.GetComponent<SphereCollider>().enabled = false;
            GameManager.Instance.MakeRobotDead(transform.localPosition);

            if (this.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                collision.gameObject.transform.parent = transform;
               Animator s = GetComponent<Animator>();
                s.SetTrigger("Dead");
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<AudioSource>().clip = GameManager.Instance.RobotDie();
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().Play();
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<SphereCollider>().enabled = false;

                Invoke("Dead", 3);
            }
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);

    }

}
