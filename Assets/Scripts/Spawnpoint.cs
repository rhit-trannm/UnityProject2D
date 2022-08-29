using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObjectPrefab;
    [SerializeField]
    private float spawnTimer = 5;
    [SerializeField]
    private int numberPerSpawn = 1;
    private float CDTimer = 0;

    public Vector2 _BoundsMin;

    public Vector2 _BoundsMax;
    private BoxCollider2D _BoxCol;

    private Camera _cam;
    Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        CDTimer = spawnTimer;
        _BoxCol = GetComponent<BoxCollider2D>();
        _BoundsMax = _BoxCol.bounds.max;
        _BoundsMin = _BoxCol.bounds.min;
        _cam = UnityEngine.Camera.main;
    }

    // Update is called once per frame
    void Update()
    {


            if (CDTimer <= 0)
            {
                for(int i = 0; i < numberPerSpawn; i++)
                {
                    Vector2 randomPos = new Vector2(Random.Range(_BoundsMin.x, _BoundsMax.x), Random.Range(_BoundsMin.y, _BoundsMax.y));
                    Vector3 viewPos = _cam.WorldToViewportPoint(randomPos);

                    if (!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
                    {
                        GameObject go = Instantiate(gameObjectPrefab, randomPos, Quaternion.identity);
                        CDTimer = spawnTimer;

                    }


                    /*                    while (!m_Renderer.isVisible)
                                        {
                                            randomPos = new Vector2(Random.Range(_BoundsMin.x, _BoundsMax.x), Random.Range(_BoundsMin.y, _BoundsMax.y));
                                            go.transform.position = randomPos;
                                        }*/
                }
        }
        else
        {
            CDTimer = CDTimer - Time.deltaTime;
        }
        

        
    }
}
