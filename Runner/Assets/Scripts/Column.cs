using UnityEngine;
using System;
public class Column : MonoBehaviour
{
    public Column leftColumn, rightColumn;
    public Vector3 moveDirection = Vector3.back;
    public Centers centers;

    [Serializable] public class Centers
    {
        public Transform left, current, right;
    }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        this.transform.Translate(moveDirection * Time.deltaTime * World.worldSpeed , Space.World);
    }
}
