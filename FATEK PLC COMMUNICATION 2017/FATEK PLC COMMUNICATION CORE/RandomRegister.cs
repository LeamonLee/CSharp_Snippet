using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialNetworks.FatekCom
{
    public class RandomRegister
    {
        private MemoryType _MemoryType;

        private ushort _Address;

        private object _Value;

        private DataType _DataType;


        public MemoryType MemoryType
        {
            get
            {
                return _MemoryType;
            }

            set
            {
                _MemoryType = value;
            }
        }

        public DataType DataType
        {
            get
            {
                return _DataType;
            }

            set
            {
                _DataType = value;
            }
        }

        public ushort Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = value;
            }
        }

        public object Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }
    }
}
