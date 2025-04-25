using UnityEngine;
using System.Collections.Generic;
using System.Drawing;

[CreateAssetMenu(fileName = "GameParams", menuName = "Scriptable Objects/GameParams")]
public class GameParams : ScriptableObject
{
    [SerializeField]
    private List<string> names;

    public int Size
    {
        get { return names.Count; }
    }

    public string GetNameByIndex(int index)
    {
        return index < names.Count ? names[index] : "None";
    }

    public IEnumerator<string> GetEnumerator()
    {
        foreach (var i in names)
            yield return i;
    }
}