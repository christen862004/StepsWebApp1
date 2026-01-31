namespace WebApp1.Repository
{
    public class Service : IService
    {
        public string Id { get; set; }
        public Service()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
