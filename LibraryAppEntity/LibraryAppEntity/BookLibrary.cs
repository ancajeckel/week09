//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryAppEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookLibrary
    {
        public int BookLibraryId { get; set; }
        public Nullable<int> LibraryId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Library Library { get; set; }
    }
}
