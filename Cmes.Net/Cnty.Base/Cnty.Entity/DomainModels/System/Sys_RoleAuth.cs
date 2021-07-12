using Cnty.Entity.SystemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnty.Entity.DomainModels
{
    [Table("Sys_RoleAuth")]
    public class Sys_RoleAuth: BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Display(Name ="")]
       [Required(AllowEmptyStrings=false)]
       public int Auth_Id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="")]
       [Column(TypeName= "uniqueidentifier")]
       public Guid? Role_Id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="")]
       [Column(TypeName="int")]
       public int? User_Id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int Menu_Id { get; set; }

       /// <summary>
       ///用户权限
       /// </summary>
       [Display(Name ="用户权限")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       [Required(AllowEmptyStrings=false)]
       public string AuthValue { get; set; }

       
    }
}
