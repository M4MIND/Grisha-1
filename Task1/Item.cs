using System;

namespace Task1
{
    class Item<TValue>
    {
        public TValue Value { get; set; }


        public Item() {
        }

        public Item(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }
    }
}
