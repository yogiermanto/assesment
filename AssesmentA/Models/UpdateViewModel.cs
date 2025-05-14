namespace AssesmentA.Models;

public class UpdateViewModel
{
    public int Id { get; set; }
    
    public string NamaBarang { get; set; } = null!;

    public string KodeBarang { get; set; } = null!;
    
    public int JumlahBarang { get; set; }
    
    public DateTime Tanggal { get; set; }
}