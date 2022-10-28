using System;

namespace Ishopping.Domain.Communs
{
    public abstract class _User
    {
        public Guid Id { get; protected set; }
        public string IdUser { get; protected set; }
        public DateTime LastChange { get; protected set; }
    }
}
