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
    [Entity(TableCnName = "Scada数据采集",TableName = "Scada_Data_Demo")]
    public class Scada_Data_Demo:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid ID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="IsDelete")]
       [Column(TypeName="int")]
       public int? IsDelete { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateDate")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateID")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string CreateID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Creater")]
       [MaxLength(60)]
       [Column(TypeName="nvarchar(60)")]
       public string Creater { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Modifier")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string Modifier { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyDate")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyID")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string ModifyID { get; set; }

       /// <summary>
       ///请求路径
       /// </summary>
       [Display(Name ="请求路径")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string RequestUrl { get; set; }

       /// <summary>
       ///请求参数
       /// </summary>
       [Display(Name ="请求参数")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string RequestData { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ResponseCode")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string ResponseCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ResponseData")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string ResponseData { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ExtendOne")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string ExtendOne { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ExtendTwo")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string ExtendTwo { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ExtendThree")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string ExtendThree { get; set; }

       
    }
}