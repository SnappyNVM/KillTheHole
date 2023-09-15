using UnityEngine;

public class Hole : MonoBehaviour
{
    private bool _isFree;

    public bool IsFree => true;

    public void SpawnMole(MoleHealth molePrefab)
    {
        Instantiate(molePrefab, transform.position, Quaternion.identity);
    }
}
