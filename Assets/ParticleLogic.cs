using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLogic : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParticlePosition(Transform enemyTrans)
    {
        transform.position = new Vector3(enemyTrans.transform.position.x, enemyTrans.transform.position.y, 0);
    }
}
