using System;

namespace AjaxExamples.Models
{
    public class Speaker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string Bio { get; set; }
        public string UrlKey { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}