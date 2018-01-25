using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Natale.Classes
{
    public class MongoDB 
    {
        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public Utente GetUser(Utente user)
        {
            IMongoCollection<Utente> userCollection = database.GetCollection<Utente>("users");
            return userCollection.Find(_ => _.Email == user.Email && _.Password == SHA512(user.Password)).FirstOrDefault();
        }

        public Giocattolo GetToy(string id)
        {
            IMongoCollection<Giocattolo> toyCollection = database.GetCollection<Giocattolo>("toys");
            return toyCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public IEnumerable<Giocattolo> GetAllToys()
        {
            IMongoCollection<Giocattolo> toysCollection = database.GetCollection<Giocattolo>("toys");
            List<Giocattolo> toysList = toysCollection.Find(new BsonDocument()).ToList();
            return toysList;
        }

        public IEnumerable<Richieste> GetAllRequestKid()
        {
            IMongoCollection<Richieste> requestCollection = database.GetCollection<Richieste>("orders");
            return requestCollection.Find(new BsonDocument()).SortBy(t => t.Date).ToList();
        }

        public Richieste GetRequest(string id)
        {
            IMongoCollection<Richieste> requestCollection = database.GetCollection<Richieste>("orders");
            return requestCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        private string SHA512(string String)
        {
            byte[] hashValue;
            byte[] message = System.Text.Encoding.UTF8.GetBytes(String);
            SHA512Managed hashString = new SHA512Managed();
            hashValue = hashString.ComputeHash(message);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashValue)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}
