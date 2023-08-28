using System;
using System.Collections.Generic;

public abstract class VariableState 
{
    public enum StateBehaviour { Set, Add, Mines }

    public static Dictionary<string, VariableState> VariablesKeyBase { private set; get; } = new Dictionary<string, VariableState>();
    public static T Get<T>(string key) where T : VariableState
    {
        if (!VariablesKeyBase.ContainsKey(key))
            return null;

        return VariablesKeyBase[key] as T;
    }
    public static T Update<T>(string key, T value) where T : VariableState
    {
        if(Get<T>(key) == null)
            VariablesKeyBase.Add(key, value);
        else
            VariablesKeyBase[key] = value;

        return VariablesKeyBase[key] as T;
    }

    public static Dictionary<Type,VariableState> Variables { private set; get; } = new Dictionary<Type, VariableState>();
    public static T Get<T>() where T : VariableState
    {
        if (!Variables.ContainsKey(typeof(T)))
            return null;

        return Variables[typeof(T)] as T;
    }
    public static T Update<T>(T value) where T : VariableState
    {
        if (Get<T>() == null)
            Variables.Add(typeof(T), value);
        else
            Variables[typeof(T)] = value;

        return Variables[typeof(T)] as T;
    }

    public static void Clear()
    {
        VariablesKeyBase.Clear();
        Variables.Clear();
    }

    public string KEY { get; protected set; }
}
