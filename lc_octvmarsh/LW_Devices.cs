using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_octvmarsh
{
    public class LW_Devices : IEnumerable
    {
        private LW_Device[] _LW_Devices;
        public LW_Devices(LW_Device[] pArray)
        {
            _LW_Devices = new LW_Device[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _LW_Devices[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public LW_DevicesEnum GetEnumerator()
        {
            return new LW_DevicesEnum(_LW_Devices);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class LW_DevicesEnum : IEnumerator
    {
        public LW_Device[] _LW_Devices;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public LW_DevicesEnum(LW_Device[] list)
        {
            _LW_Devices = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _LW_Devices.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public LW_Device Current
        {
            get
            {
                try
                {
                    return _LW_Devices[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }
}
