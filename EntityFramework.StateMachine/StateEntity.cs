using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Stateless;

namespace EntityFramework.StateMachine
{
    //<State, Trigger>
    public class StateEntity<T, TR>
    {
        [NotMapped]
        public T CurrentState { get; set; }

        [NotMapped]
        public StateMachine<T, TR> State { get; set; }

        [NotMapped]
        public IEnumerable<TR> Allowed => State.PermittedTriggers;

        public StateEntity()
        {
            State = new StateMachine<T, TR>(() => CurrentState, (t) => CurrentState = t);
        }
    }
}
