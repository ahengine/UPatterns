using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UPatterns
{
    public record UState
    {
        public static T FromJson<T>(string json) where T : UState =>
            JsonConvert.DeserializeObject<T>(json);
    }

    public static class UStateRepo {
        private static Dictionary<Type, UState> states = new Dictionary<Type, UState>();
        
        public static T GetState<T>() where T : UState =>
            states[typeof(T)] as T;
        public static T SetState<T>(T state) where T : UState
        {
            if(!states.ContainsKey(typeof(T)))
                states.Add(typeof(T), state);
            else
                states[typeof(T)] = state;

            return state;
        }
    }
}