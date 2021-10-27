namespace MaroonMaggot.Web.ApiModels
{
    public class CreateAccountDTO
    {
        public string Name { get;set; } = string.Empty;
        public int? ParentAccountId { get; set; }
    }
}
