//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sprotify_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlbumArtiest
    {
        public int id { get; set; }
        public int albumId { get; set; }
        public int artiestId { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Artiest Artiest { get; set; }
    }
}
