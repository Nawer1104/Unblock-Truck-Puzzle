using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public List<Enum> thisLevelTypes;

    public void SetTypeOtherTrunk(Enum type)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].GetComponent<Trunk>().type == Enum.None)
            {
                for (int j = 0; j < thisLevelTypes.Count; j++)
                {
                    if(thisLevelTypes[j] != type)
                    {
                        gameObjects[i].GetComponent<Trunk>().type = thisLevelTypes[j];
                    }
                }
            }
        }
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
