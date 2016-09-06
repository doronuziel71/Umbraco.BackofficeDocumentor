using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Newtonsoft.Json;
using Umbraco.BackofficeDocumentor.Models;

namespace Umbraco.BackofficeDocumentor.Services
{
    public class SnapshotService : ISnapshotService
    {
        private string appPath;
        private BackofficeDocumentor _documentor;

        public SnapshotService()
        {
            this.appPath = HostingEnvironment.MapPath("~/App_Data/BackofficeSnapshots/");
            this._documentor = new Services.BackofficeDocumentor();
        }

        public IEnumerable<string> List()
        {
            var dir = EnsureDirectory();
            if (dir == null)
                throw new Exception("Cannot find working directory for snapshots" + appPath);

            var files = dir.GetFiles("*.json").Select(x => x.Name).ToArray();

            return files;

        }

        public BackofficeDocumentModel Get(string file)
        {
            var dir = EnsureDirectory();
            var path = Path.Combine(appPath, file);
            using (var reader = new StreamReader(File.Open(path, FileMode.Open)))
            {
                var json = reader.ReadToEnd();
                var model = JsonConvert.DeserializeObject < BackofficeDocumentModel>(json);
                return model;

            }
        }

        public string Save(string newNampe, string OldName, BackofficeDocumentModel model)
        {
            var dir = EnsureDirectory();
            var oldpath = Path.Combine(appPath, OldName);
            var rawFileName = Path.GetFileNameWithoutExtension(newNampe) + ".json";
            var newpath = Path.Combine(appPath, rawFileName);


            if (oldpath == null || !File.Exists(oldpath))
                throw new Exception("Not Found old file");

            if (newpath != oldpath && File.Exists(newpath))
                throw new Exception("File already exists");


            File.Delete(oldpath);
            using (var sw = new StreamWriter(File.OpenWrite(newpath)))
            {
                sw.Write(JsonConvert.SerializeObject(model));
            }


            return Path.GetFileName(newpath);
        }

        public string New()
        {
            var dir = EnsureDirectory();
            var snapshot = _documentor.CreateSnapshot();

            var json = JsonConvert.SerializeObject(snapshot);

            var fileName = string.Format("{0:yyyy MMMM dd HH mm ss}.json", DateTime.Now);
            var path = Path.Combine(appPath, fileName);
            using (var fw = File.CreateText(path: path))
            {
                fw.Write(json);
            }

            return fileName;
        }

        public void Delete(string file)
        {
            var path = Path.Combine(appPath, file);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

         
        }



        private DirectoryInfo EnsureDirectory()
        {
  

            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);

            }

            return new DirectoryInfo(appPath);


        }
    }
}