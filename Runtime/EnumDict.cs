using System;
using System.Linq;
using UnityEngine;
using static Dev.ComradeVanti.EnumDict.EnumUtil;

namespace Dev.ComradeVanti.EnumDict
{

    [Serializable]
    public class EnumDict<TEnum, TData>
        where TEnum : Enum
    {

#if UNITY_EDITOR
        [SerializeField] private string enumTypeName;
        [SerializeField] private bool isOpen;
#endif
        [SerializeField] private Entry[] entries;


#if UNITY_EDITOR
        public EnumDict()
        {
            enumTypeName = typeof(TEnum).AssemblyQualifiedName;
            entries = GetEnumValues<TEnum>()
                      .Select(it => new Entry(it, default))
                      .ToArray();
        }
#endif


        public TData Get(TEnum key) =>
            entries.First(it => it.Enum.Equals(key)).Value;
        
        public TData this[TEnum key] => Get(key);


        [Serializable]
        private struct Entry
        {

            [SerializeField] private TEnum @enum;
            [SerializeField] private TData value;


            public TEnum Enum => @enum;

            public TData Value => value;


            public Entry(TEnum @enum, TData value)
            {
                this.@enum = @enum;
                this.value = value;
            }

        }

    }

}