using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cnty.Entity.SystemModels
{ 
    /// <summary>
    /// 针对主键必须是 GUID的通用基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }
        /// <summary>
        ///主键ID
        /// </summary>
        [Key]
        [Display(Name = "主键ID")]
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        public Guid Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        [Display(Name = "CreateID")]
        [Column(TypeName = "string")]
        public string CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "nvarchar(255)")]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Creater { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "ModifyID")]
        [Column(TypeName = "nvarchar(255)")]
        public string ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        ///是否删除0未删除1删除
        /// </summary>
        [Display(Name = "是否删除")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int IsDelete { get; set; }
    }
}
