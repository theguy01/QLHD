﻿using QLHD.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHD.Model.Models
{
    [Table("Contractor")]
    public class Contractor : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(4)]
        [MaxLength(12)]
        [Display(Name = "Mã Nhà Thầu")]
        public string Code { get; set; }

        [Display(Name = "Tên Nhà Thầu")]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(13)]
        [Display(Name = "Mã Số Thuế")]
        public string TaxCode { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Display(Name = "Người Đại Diện")]
        public string Representative { get; set; }

        [Display(Name = "TK Ngân Hàng Số")]
        public string BankAccountNo { get; set; }

        [Display(Name = "Tại Ngân Hàng")]
        public string BankName { get; set; }

        [Display(Name = "SĐT")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Danh Sách Hợp Đồng")]
        public virtual ICollection<Contract> Contracts { get; set; }


    }
}
