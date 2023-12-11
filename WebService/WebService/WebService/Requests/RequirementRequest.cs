namespace WebService.Requests{
    public class RequirementRequest{
        public string ?user { get; set; }
        public string ?description{ get; set; }
        public ICollection<ConceptRequest> ?concepts { get; set; }   
    }
}