using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("error", Schema = "Usuarios")]
public partial class Error
{
    [Key]
    [Column("id_error")]
    public int IdError { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("controller")]
    public string? Controller { get; set; }

    [Column("ip")]
    [StringLength(100)]
    public string? Ip { get; set; }

    [Column("method")]
    [StringLength(100)]
    public string? Method { get; set; }

    [Column("user_agent")]
    [StringLength(100)]
    public string? UserAgent { get; set; }

    [Column("host")]
    [StringLength(100)]
    public string? Host { get; set; }

    [Column("class_component")]
    [StringLength(100)]
    public string? ClassComponent { get; set; }

    [Column("function_name")]
    [StringLength(100)]
    public string? FunctionName { get; set; }

    [Column("code_line_number")]
    public int? CodeLineNumber { get; set; }

    [Column("error")]
    [StringLength(100)]
    public string? Error1 { get; set; }

    [Column("srack_tace")]
    [StringLength(100)]
    public string? SrackTace { get; set; }

    [Column("status")]
    public short? Status { get; set; }

    [Column("request")]
    [StringLength(100)]
    public string? Request { get; set; }

    [Column("error_code")]
    public int? ErrorCode { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Errors")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
