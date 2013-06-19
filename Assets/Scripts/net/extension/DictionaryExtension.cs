using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.net.extension {
    public static class DictionaryExtension {
        public static TValue GetRandomItemViaUnityRandom<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            TValue[] flatten = dictionary.Select(x => x.Value).ToArray();

            return flatten[Random.Range(0, flatten.Length)];
        }

        public static TValue GetRandomItemViaSystemRandom<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            TValue[] flatten = dictionary.Select(x => x.Value).ToArray();

            var rnd = new System.Random();
            return flatten[rnd.Next(0, flatten.Length)];
        }

        //

        public static TKey GetRandomKeyViaUnityRandom<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            TKey[] flatten = dictionary.Keys.ToArray();
            return flatten[Random.Range(0, dictionary.Keys.Count)];
        }

        public static TKey GetRandomKeyViaSystemRandom<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
            var rnd = new System.Random();
            TKey[] flatten = dictionary.Keys.ToArray();
            return flatten[rnd.Next(0, dictionary.Keys.Count)];
        }
    }
}