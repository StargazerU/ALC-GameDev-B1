using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP, maxHP, ScoreToGive;

    [Header("Movement")]
    public float moveSpeed, attackRange, yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //Gathe the compnets
        weopon = GetComponent<weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
    }

    void UpdatePath()
    {
        //Calculate a path to the target
        NavMeshPath NavMeshPath = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, target.transform.position, NavMeshPath.AllAreas, navMeshPath);

        //Save calculated path to the list
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return

        //Movetoweard the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed + Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0,yPathOffset,0))
            path.RemoveAt(0);    
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
