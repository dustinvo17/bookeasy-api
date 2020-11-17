using System;
using MongoDB.Bson;

namespace Bookeasy.Domain.Common
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}