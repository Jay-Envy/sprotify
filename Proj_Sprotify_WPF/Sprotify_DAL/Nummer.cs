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
    
    public partial class Nummer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nummer()
        {
            this.ArtiestNummers = new HashSet<ArtiestNummer>();
            this.Comments = new HashSet<Comment>();
            this.PlaylistNummers = new HashSet<PlaylistNummer>();
            this.NummerGenres = new HashSet<NummerGenre>();
        }
    
        public int id { get; set; }
        public string titel { get; set; }
        public int aantalKeerGespeeld { get; set; }
        public int lengte { get; set; }
        public string regio { get; set; }
        public Nullable<bool> like { get; set; }
        public int albumId { get; set; }
        public int sourceId { get; set; }
    
        public virtual Album Album { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtiestNummer> ArtiestNummers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistNummer> PlaylistNummers { get; set; }
        public virtual Source Source { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NummerGenre> NummerGenres { get; set; }
    }
}