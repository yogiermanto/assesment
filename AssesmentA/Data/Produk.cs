using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssesmentA.Data;

[Table("produk")]
public class Produk
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nama_barang")]
    [MaxLength(200)]
    public string NamaBarang { get; set; } = null!;

    [Column("kode_barang")]
    [MaxLength(50)]
    public string KodeBarang { get; set; } = null!;
    
    [Column("jumlah_barang")]
    public int JumlahBarang { get; set; }
    
    [Column("tanggal", TypeName = "datetime")]
    public DateTime Tanggal { get; set; }
}