using InscaleApi.Models;

namespace InscaleApi.Services
{
    public class ResourceServices
    {
        private List<Resource> _resources;

        public ResourceServices(List<Resource> resourse)
        {
            _resources = resourse;
        }

        public List<Resource> GetAllResources()
        {
            return _resources;
        }
    }
}
