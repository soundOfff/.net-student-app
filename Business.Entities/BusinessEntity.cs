using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private States _State;

        public States State { get { return _State; } set { _State = value; } }

        public BusinessEntity()
        {
            this.State = States.New;    
        }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
