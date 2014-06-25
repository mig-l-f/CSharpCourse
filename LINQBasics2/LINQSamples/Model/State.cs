using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples.Model
{
    class State : IEquatable<State>
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public bool Equals(State other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            else
            {
                if (StateId == other.StateId && StateName == StateName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override int GetHashCode()
        {
            return StateId.GetHashCode() ^ StateName.GetHashCode();
        }
    }      
}
