//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CurseWaterPool
{
    using System;
    using System.Collections.Generic;
    
    public partial class hystory
    {
        public int id { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<int> idSubscription { get; set; }
        public Nullable<System.DateTime> dateActivation { get; set; }
        public Nullable<System.DateTime> dateValidity { get; set; }
    
        public virtual subscription subscription { get; set; }
        public virtual users users { get; set; }
    }
}
