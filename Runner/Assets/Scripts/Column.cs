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
        if (GameManager.Instance.gameStarted && Player.instance.playerStats.IsAlive)
        {
            Move();
        }
    }
    void Move()
    {
        this.transform.Translate(Time.deltaTime * World.worldSpeed * moveDirection , Space.World);
    }
}
