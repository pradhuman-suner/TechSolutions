//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechSolutionsApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Query
    {
        public int Id { get; set; }
        public string Ques { get; set; }
        public string Title { get; set; }
        public Nullable<int> CatId { get; set; }
        public Nullable<System.DateTime> QDatetime { get; set; }
        public string QStatus { get; set; }
        public Nullable<int> UId { get; set; }
        public Nullable<int> LikeCount { get; set; }
        public Nullable<int> AnsCount { get; set; }
        public Nullable<int> CommentCount { get; set; }
        public string UserName { get; set; }
    }
}
