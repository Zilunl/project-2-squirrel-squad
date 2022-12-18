using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleTreeGenerate : MonoBehaviour
{
    
    [SerializeField] GameObject[] prefabs;

    [SerializeField] int numOfPrefabs;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 zRange;
    [SerializeField] float yPosition;
    [SerializeField] List<Vector2> dontGenerateXRange = new List<Vector2>();
    [Space]


    [SerializeField, Range(0, 1)] float rotateTowardsNormal;
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
        
        
        for (int i = 0; i < numOfPrefabs; i++)
        {
            float x = Random.Range(xRange.x, xRange.y);
            float z = Random.Range(zRange.x, zRange.y);
            bool canGenerate = true;
            if (dontGenerateXRange.Count != 0)
            {
                for (int j = 0; j < dontGenerateXRange.Count; j++)
                {
                    float cantGenerateXL = dontGenerateXRange[j].x;
                    float cantGenerateXR = dontGenerateXRange[j].y;
                    if (x <= cantGenerateXR && x >= cantGenerateXL)
                    {
                        canGenerate = false;
                        break;
                    }
                }
            }
            if (!canGenerate) continue;
            
            int prefabIndex = Random.Range(0, prefabs.Length);
            GameObject prefab;
           
            prefab = Instantiate(prefabs[prefabIndex], new Vector3(x, yPosition, z), Quaternion.identity);
            prefab.transform.SetParent(this.transform, true);



            prefab.transform.position = new Vector3(x, yPosition, z);
            prefab.transform.Rotate(Vector3.up, Random.Range(rotationRange.x, rotationRange.y), Space.Self);
            prefab.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.FromToRotation(Vector3.up, new Vector3(0,1,0)), rotateTowardsNormal);
            prefab.transform.localScale = new Vector3(
                Random.Range(minScale.x, maxScale.x),
                Random.Range(minScale.y, maxScale.y),
                Random.Range(minScale.z, maxScale.z)
            );
        }
    }

        // Update is called once per frame

}
