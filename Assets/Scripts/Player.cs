using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Shot shot;
    private Cursor cursor;
    private NavMeshAgent _navMeshAgent;

    public float moveSpeed;
    public Transform gunBarrel;

    void Awake()
    {
        // Singleton 
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        cursor = FindObjectOfType<Cursor>();
        shot = FindObjectOfType<Shot>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) dir.z = -1.0f;
        if (Input.GetKey(KeyCode.D)) dir.z = 1.0f;
        if (Input.GetKey(KeyCode.S)) dir.x = 1.0f;
        if (Input.GetKey(KeyCode.W)) dir.x = -1.0f;
        _navMeshAgent.velocity = dir.normalized * moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            var from = gunBarrel.position;
            var target = cursor.transform.position;
            var to = new Vector3(target.x, from.y, target.z);
            var direction = (to - from).normalized;

            RaycastHit hit;
            if (Physics.Raycast(from, direction, out hit, 100))
            {
                if (hit.transform != null)
                {
                    var zombie = hit.transform.GetComponent<Zombie>();
                    if (zombie != null)
                        zombie.Kill();
                }

                to = new Vector3(hit.point.x, from.y, hit.point.z);
            }
            else
            {
                to = from + direction * 100;
            }

            var shotInstance = ShotPool.Instance.GetShot();
            shotInstance.Show(from, to);
        }

        Vector3 forward = cursor.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
    }
}
