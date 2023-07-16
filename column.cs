using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class column : MonoBehaviour
{
    public Transform checker;
    public LayerMask Player_layer;
    public bool column_;
    public bool broke=false;
    Vector3 velocity;
    private float yok_olus;
    void Update()
    {

        column_ = Physics.CheckBox(checker.position, new Vector3(10f, 0.5f, 10f), Quaternion.identity, Player_layer);

        if(column_)
        {
            broke = true;
        }

        if(broke)
        {
            velocity.y -= Time.deltaTime/50;
            yok_olus += Time.deltaTime;
        }

        transform.Translate(velocity);

        if(yok_olus>=10f)
        {
            broke = false;
            Destroy(this.gameObject);
        }



    }
}
