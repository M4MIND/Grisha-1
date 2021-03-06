using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    
    class Multiple <TValue>
    {
        public List<Item<TValue>> collection = new List<Item<TValue>>();

        public int Count => collection.Count;

        public void Add(Item<TValue> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Has(item))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {item.Value}.", nameof(item));
            }

            collection.Add(item);
        }

        public void Add (TValue v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }

            if (Has(v))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {v}.", nameof(v));
            }

            collection.Add(new Item<TValue>(v));
        }

        public TValue Get(TValue v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }

            Item<TValue> i = collection.SingleOrDefault(i => i.Value.Equals(v)) ?? throw new ArgumentException($"Словарь не содержит значение с ключом {v}.", nameof(v));

            return i.Value;
        }

        public static Multiple<TValue> Union(Multiple<TValue> multiple1, Multiple<TValue> multiple2)
        {
            Multiple<TValue> collection = new Multiple<TValue>();

            multiple1.collection.ForEach(i =>
            {
                if (!collection.Has(i.Value))
                {
                    collection.Add(i);
                }
            });


            multiple2.collection.ForEach(i =>
            {
                if (!collection.Has(i.Value))
                {
                    collection.Add(i);
                }
            });


            return collection;
        }

        public static Multiple<TValue> Intersect (Multiple<TValue> multiple1, Multiple<TValue> multiple2)
        {
            Multiple<TValue> collection = new Multiple< TValue>();
            multiple1.collection.ForEach(i =>
            {
                if (multiple2.Has(i.Value))
                {
                    collection.Add(i);
                }
            });

            return collection;
        }

        public static Multiple<TValue> Difference(Multiple<TValue> multiple1, Multiple<TValue> multiple2)
        {
            Multiple<TValue> collection = new Multiple<TValue>();
            multiple1.collection.ForEach(i =>
            {
                if (!multiple2.Has(i.Value))
                {
                    collection.Add(i);
                }
            });

            return collection;
        }

        public bool Has(Item<TValue> item)
        {
            return collection.Any(i => i.Value.Equals(item.Value));
        }

        public bool Has(TValue v)
        {
            return collection.Any(i => i.Value.Equals(v));
        }
    }
}
