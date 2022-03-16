namespace SAMS.Services.ADOApartmentServices
{
    public class ADOApartmentService : IApartmentService
    {
        private ADOApartment service;
        public ADOApartmentService(ADOApartment service)
        {
            this.service = service;
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return service.GetApartments();
        }
    }
}
