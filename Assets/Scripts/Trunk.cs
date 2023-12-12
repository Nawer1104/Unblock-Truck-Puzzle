using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
    public Enum type;

    public List<Transform> slots;

    private int index = 0;

    private bool isFull = false;

    public void SetType(Enum type)
    {
        this.type = type;
    }

    public void StockingCar(Car car)
    {
        if (type == Enum.None)
        {
            type = car.type;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].SetTypeOtherTrunk(type);
        }

        if (car.type != type || isFull)
        {
            car.ReSetPos();
            return;
        }

        car.moveAble = false;
        car.GetComponent<BoxCollider2D>().enabled = false;
        car.gameObject.transform.position = slots[index].position;
        car.Success();
        index += 1;

        if (index == slots.Count)
        {
            isFull = true;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
        }
    }

}
