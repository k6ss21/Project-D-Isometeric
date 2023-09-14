using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();
    public void OnAfterDeserialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnBeforeSerialize()
    {
        this.Clear();
        if (keys.Count != values.Count)
        {
            Debug.LogError("Tried to deserialize a serializableDictionary, but the amount of keys  (" 
            + keys.Count + ")does not match the number of values 9" + values.Count +
             ") means something went wrong");
        }
        int keyCount  = keys.Count;
        for (int i = 0; i < keyCount; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
