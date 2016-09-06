using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Hosting;
using System.Web.Http;
using Newtonsoft.Json;
using Umbraco.BackofficeDocumentor.Models;
using Umbraco.BackofficeDocumentor.Services;
using Umbraco.Web.WebApi;

namespace Umbraco.BackofficeDocumentor.Controllers
{
    public class SnapshotsController : UmbracoAuthorizedApiController
    {
        private readonly Services.BackofficeDocumentor _documentor;
        private readonly ISnapshotService _snapshotService;

        public SnapshotsController()
        {
            this._documentor = new Services.BackofficeDocumentor();
            this._snapshotService = new SnapshotService();
            

        }

        [HttpGet]
        public IHttpActionResult List()
        {
            return Ok(_snapshotService.List());
        }


         [HttpGet]
        public IHttpActionResult Get(string name)
         {
             return Ok(_snapshotService.Get(name));
         }


        [HttpPost]
        public IHttpActionResult Rename( SnapshotSaveOrRenameModel model)
        {
          
            return Ok(_snapshotService.Save(model.NewName,model.OldName,model.Snapshot));
        }

        [HttpPost]
        public IHttpActionResult New()
        {
           

            return Ok(_snapshotService.New());
        }

        [HttpPost]
        public IHttpActionResult Delete(string file)
        {
            _snapshotService.Delete(file);

            return Ok();
        }

      
    }
}