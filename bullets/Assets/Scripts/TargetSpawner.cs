using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private int targetNubmer = 3;
    [SerializeField] private GameObject targetPrefab;
    private List<Target> targets = new List<Target>();
    private int currentTargetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < targetNubmer; i++)
        {
            this.StartCoroutine(SpawnTargetRoutine());
        }
    }

    private IEnumerator SpawnTargetRoutine()
    {
        yield return new WaitForSeconds(.1f);
        GameObject targetGO = Instantiate(targetPrefab, transform.position + GetRandomOffset(), Quaternion.identity);
        Target target = targetGO.GetComponent<Target>();
        targets.Add(target);
    }

    private Vector3 GetRandomOffset()
    {
        return new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
    }


    public Target GetTarget()
    {
        Target t = targets[currentTargetIndex];
        currentTargetIndex = currentTargetIndex < targetNubmer - 1 ? currentTargetIndex++ : 0;
        return t;
    }
}