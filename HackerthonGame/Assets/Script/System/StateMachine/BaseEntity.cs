using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    private static int m_iNestValidID = 0;

    private string id;
    public string ID
    {
        set {
            id = value;
            m_iNestValidID++;
        }
        get => id;
    }


    private string entityName;

    public virtual void Setup(string name)
    {
        ID = name + m_iNestValidID;
        entityName = name;
    }
}
