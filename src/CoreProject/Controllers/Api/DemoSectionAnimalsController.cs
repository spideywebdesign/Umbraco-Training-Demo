using CoreProject.Repositories.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace CoreProject.Controllers.Api
{
    public class DemoSectionAnimalsController : UmbracoAuthorizedApiController
    {
        private readonly IDemoSectionAnimalsRepository _demoSectionAnimalsRepository;

        public DemoSectionAnimalsController(IDemoSectionAnimalsRepository demoSectionAnimalsRepository)
        {
            _demoSectionAnimalsRepository = demoSectionAnimalsRepository;
        }
 
        [HttpGet]
        public object GetAnimal(int animalId)
        {
            var animal = _demoSectionAnimalsRepository.GetById(animalId);
            if (animal == null) return Request.CreateResponse(HttpStatusCode.NotFound);
        
            return animal;
        }
    }
}