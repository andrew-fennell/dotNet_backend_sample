using System;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace LvvlStarterNetApi.Core.Models
{
    public class Comment : IComment
    {
        public string Author { get; set; }
        public string Text { get; set; }
    }
}