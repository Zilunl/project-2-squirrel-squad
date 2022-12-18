using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerate : MonoBehaviour
{
    [SerializeField] GameObject treePrefab;
    [Header("Raycast settings")]
    [SerializeField] int density;

    
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;

    [Header("Tree settings")]
    [SerializeField, Range(0, 1)] float rorareTowardsNormal; 
    [SerializeField] Vector3 minScale;
    [SerializeField] Vector3 maxScale;
    [SerializeField] Vector2 rotationRange;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }
    public void Generate() 
    {
        
        
        for (int i = 0; i < density; i++)
        {
            float x = Random.Range(xRange.x, xRange.y);
            float z = Random.Range(zRange.x, zRange.y);
            Vector3 position = new Vector3(x, 10, z);
            RaycastHit hit;
            if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity))
            {
                
                if (hit.point.y >= minHeight && hit.point.y<=maxHeight)
                {
                    GameObject testTree = Instantiate(treePrefab, transform);
                    GameObject tree = Instantiate(treePrefab, hit.point, Quaternion.identity);
                    tree.transform.position = hit.point;
                    tree.transform.Rotate(Vector3.up, Random.Range(rotationRange.x, rotationRange.y), Space.Self);
                    tree.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.FromToRotation(Vector3.up, hit.normal), rorareTowardsNormal);
                    tree.transform.localScale = new Vector3(
                        Random.Range(minScale.x, maxScale.x),
                        Random.Range(minScale.y, maxScale.y),
                        Random.Range(minScale.z, maxScale.z)
                    );
                }
            }
        }
    }
    
}

