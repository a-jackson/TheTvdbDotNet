using System;
using System.Collections.Generic;
using System.Linq;

namespace TheTvdbDotNet.Http
{
    public class Request
    {
        private string resource;
        private object id;
        private List<Tuple<string, string>> criteria;

        public Request(string resource)
            : this(resource, null)
        {
        }

        public Request(string resource, object id)
        {
            this.resource = resource;
            this.id = id;
            criteria = new List<Tuple<string, string>>();
        }

        public void AddCriteria(string name, string value)
        {
            criteria.Add(new Tuple<string, string>(name, value));
        }

        public void AddCriteriaIfNotNull(string name, string value)
        {
            if (value != null)
            {
                AddCriteria(name, value);
            }
        }

        public string BuildRequest() =>
            BuildResource() + BuildCriteria();

        private string BuildResource() =>
            id == null ? resource : BuildResourceWithId();

        private string BuildResourceWithId() =>
            resource.Replace("{id}", EncodeString(id.ToString()));

        private string BuildCriteria() =>
            criteria.Any() ?
                "?" + criteria
                    .Select(x => string.Concat(EncodeString(x.Item1), "=", EncodeString(x.Item2)))
                    .Aggregate((x, y) => string.Concat(x, "&", y)) :
                string.Empty;

        private string EncodeString(string value) =>
            Uri.EscapeUriString(value);
    }
}
