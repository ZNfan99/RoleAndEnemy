using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool
{
    // ����GameObject
    public static void Attach(GameObject ParentObj, GameObject ChildObj, Vector3 Pos)
    {
        ChildObj.transform.parent = ParentObj.transform;
        ChildObj.transform.localPosition = Pos;
    }

    // ����GameObject
    public static void AttachToRefPos(GameObject ParentObj, GameObject ChildObj, string RefPointName, Vector3 Pos)
    {
        // Search 
        bool bFinded = false;
        Transform[] allChildren = ParentObj.transform.GetComponentsInChildren<Transform>();
        Transform RefTransform = null;
        foreach (Transform child in allChildren)
        {
            if (child.name == RefPointName)
            {
                if (bFinded == true)
                {
                    Debug.LogWarning("���[" + ParentObj.transform.name + "]���Ѓɂ����ϵą����c[" + RefPointName + "]");
                    continue;
                }
                bFinded = true;
                RefTransform = child;
            }
        }

        //  �Ƿ��ҵ�
        if (bFinded == false)
        {
            Debug.LogWarning("���[" + ParentObj.transform.name + "]�ț]�Ѕ����c[" + RefPointName + "]");
            Attach(ParentObj, ChildObj, Pos);
            return;
        }

        ChildObj.transform.parent = RefTransform;
        ChildObj.transform.localPosition = Pos;
        //ChildObj.transform.localScale = Vector3.one;
        ChildObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    // �ҵ������ϵ����
    public static GameObject FindGameObject(string GameObjectName)
    {
        // �ҳ�������GameObject
        GameObject pTmpGameObj = GameObject.Find(GameObjectName);
        if (pTmpGameObj == null)
        {
            Debug.LogWarning("�������Ҳ���GameObject[" + GameObjectName + "]���");
            return null;
        }
        return pTmpGameObj;
    }

    // ȡ�������
    public static GameObject FindChildGameObject(GameObject Container, string gameobjectName)
    {
        if (Container == null)
        {
            Debug.LogError("NGUICustomTools.GetChild : Container =null");
            return null;
        }

        Transform pGameObjectTF = null; //= Container.transform.FindChild(gameobjectName);											


        // �ǲ���Container����
        if (Container.name == gameobjectName)
            pGameObjectTF = Container.transform;
        else
        {
            // �ҳ�������Ԫ��						
            Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == gameobjectName)
                {
                    if (pGameObjectTF == null)
                        pGameObjectTF = child;
                    else
                        Debug.LogWarning("Container[" + Container.name + "]���ҳ��ظ���Ԫ�����Q[" + gameobjectName + "]");
                }
            }
        }

        // ���]���ҵ�
        if (pGameObjectTF == null)
        {
            Debug.LogError("Ԫ��[" + Container.name + "]�Ҳ�����Ԫ��[" + gameobjectName + "]");
            return null;
        }

        return pGameObjectTF.gameObject;
    }

    public static List<GameObject> FindAllChildGameObject(GameObject Container, string gameobjectName)
    {
        if (Container == null)
        {
            Debug.LogError("NGUICustomTools.GetChild : Container =null");
            return null;
        }
        Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
        List<GameObject> list = new List<GameObject>();
        foreach (var item in allChildren)
        {
            list.Add(item.gameObject);
        }
        return list;
    }

    public static List<GameObject> FindGameObjectsByTag(string tag)
    {
        GameObject[] allGameObject = GameObject.FindGameObjectsWithTag(tag);
        if (allGameObject == null)
        {
            Debug.LogError("û�д�Tag������");
        }
        List<GameObject> list = new List<GameObject>();
        foreach (var item in allGameObject)
        {
            list.Add(item);
        }
        return list;
    }
}
