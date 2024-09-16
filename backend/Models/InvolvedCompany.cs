namespace backend.Models;

public class InvolvedCompany
{
    private long CompanyId { get; set; }
    private long GameId { get; set; }
    private bool Developer { get; set; }
    private bool Publisher { get; set; }
    private bool Supporting { get; set; }
}