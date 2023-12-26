using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool
{
    private Dictionary<int, List<GameObject>> objectPool = new Dictionary<int, List<GameObject>>();
    private bool isNewCreate = false;

    public ObjectPool(GameEvent gameEvent)
    {
        gameEvent.ReleaseObject += ReleaseGameObject;
    }

    public GameObject GetGameObject(GameObject prefab)
    {
        int hashCode = prefab.GetHashCode();

        if (objectPool.ContainsKey(hashCode))
        {
            List<GameObject> gameObjectList = objectPool[hashCode];

            for (int i = 0; i < gameObjectList.Count; i++)
            {
                GameObject gameObject = gameObjectList[i];

                if (!gameObject.activeSelf)
                {
                    gameObject.SetActive(true);
                    Debug.Log(gameObject.name + "を再利用");
                    return gameObject;
                }
            }

            GameObject newGameObject = Object.Instantiate(prefab);
            gameObjectList.Add(newGameObject);
            isNewCreate = true;
            Debug.Log(newGameObject.name + "を新規作成");
            return newGameObject;
        }
        else
        {
            GameObject newGameObject = Object.Instantiate(prefab);
            objectPool.Add(hashCode, new List<GameObject>());
            objectPool[hashCode].Add(newGameObject);
            isNewCreate = true;
            Debug.Log(newGameObject.name + "を新規作成");
            return newGameObject;
        }
    }

    private void ReleaseGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public List<GameObject> GetPoolList(GameObject prefab)
    {
        int hashCode = prefab.GetHashCode();

        if (objectPool.ContainsKey(hashCode))
        {
            return objectPool[hashCode];
        }
        else
        {
            return null;
        }
    }

    public bool IsNewCreate { get => isNewCreate; set => isNewCreate = value; }
}
