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
using Cnty.Entity;

namespace Cnty.Entity.DomainModels
{
    [Entity(TableCnName = "入料管控",TableName = "Rgm_In_Data")]
    public class Rgm_In_Data:BaseEntity
    {
        /// <summary>
       ///主键
       /// </summary>
       [Key]
       [Display(Name ="主键")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid ID { get; set; }

       /// <summary>
       ///是否删除0未删除1删除
       /// </summary>
       [Display(Name ="是否删除0未删除1删除")]
       [Column(TypeName="int")]
       public int? IsDelete { get; set; }

       /// <summary>
       ///更新人
       /// </summary>
       [Display(Name ="更新人")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string Modifier { get; set; }

       /// <summary>
       ///更新日期
       /// </summary>
       [Display(Name ="更新日期")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///更新人ID
       /// </summary>
       [Display(Name ="更新人ID")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string ModifyID { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///创建ID
       /// </summary>
       [Display(Name ="创建ID")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string CreateID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string Creater { get; set; }

       /// <summary>
       ///车牌
       /// </summary>
       [Display(Name ="车牌")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string LicensePlate { get; set; }

       /// <summary>
       ///入库量
       /// </summary>
       [Display(Name ="入库量")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string StorageVolume { get; set; }

       /// <summary>
       ///入库时间
       /// </summary>
       [Display(Name ="入库时间")]
       [Column(TypeName="datetime")]
       public DateTime? InTime { get; set; }

       /// <summary>
       ///备存数据1
       /// </summary>
       [Display(Name ="备存数据1")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string KeepData1 { get; set; }

       /// <summary>
       ///备存数据2
       /// </summary>
       [Display(Name ="备存数据2")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string KeepData2 { get; set; }

       
    }
}