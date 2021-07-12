/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnty.Entity.SystemModels;

namespace Cnty.Entity.DomainModels
{
    [Table("App_TransactionAvgPrice")]
    [Entity(TableCnName = "成交均价")]
    public class App_TransactionAvgPrice:BaseEntity
    {
      

       /// <summary>
       ///品种
       /// </summary>
       [Display(Name ="品种")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string Variety { get; set; }

       /// <summary>
       ///月龄
       /// </summary>
       [Display(Name ="月龄")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string AgeRange { get; set; }

       /// <summary>
       ///城市
       /// </summary>
       [Display(Name ="城市")]
       [MaxLength(15)]
       [Column(TypeName="nvarchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string City { get; set; }

       /// <summary>
       ///成交均价
       /// </summary>
       [Display(Name ="成交均价")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal AvgPrice { get; set; }

       /// <summary>
       ///成交日期
       /// </summary>
       [Display(Name ="成交日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime Date { get; set; }

       /// <summary>
       ///是否推荐价格
       /// </summary>
       [Display(Name ="是否推荐价格")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int IsTop { get; set; }

       /// <summary>
       ///是否启用
       /// </summary>
       [Display(Name ="是否启用")]
       [Column(TypeName="tinyint")]
       public byte? Enable { get; set; }

     
    }
}
