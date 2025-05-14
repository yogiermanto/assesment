namespace AssesmentA.Models;

public class CreateViewModel
{
    public string NamaBarang { get; set; } = null!;

    public string KodeBarang { get; set; } = null!;
    
    public int JumlahBarang { get; set; }
    
    public DateTime Tanggal { get; set; }
}