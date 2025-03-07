using System.Collections;

namespace BlogMicroservice.BlogService
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class BlogApiEndpoints
        {
            private const string Base = $"{ApiBase}/posts";
            public const string Create = Base;
            public const string GetAll = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";

            public const string GetByAuthor = $"{Base}/by-author/{{authorId:int}}";
            public const string GetByLabel = $"{Base}/by-label/{{label:string}}";
        }
        }



        }
        


   

